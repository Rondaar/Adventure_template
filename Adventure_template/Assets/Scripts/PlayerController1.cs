using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {



    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float runMultiplayer = 1f; //may implement running
    [SerializeField]
    private bool facingRight;

    [Header("Waypoints")]
    
    public Transform[] waypoints;
    
    public int leftWaypointIndex;
    
    public int rightWaypointIndex;
    private Transform leftWaypoint;
    private Transform rightWaypoint;

    [SerializeField]
    private GameObject focus;

    public bool canUseInventory=true;
    public bool performingAction = false;

   // [HideInInspector]
    public Equipment actionItem;

    private Inventory inventory;
    private Animator myAnim;
    //private bool holdingObject = false;
    /*
    #region OnSceneLoaded
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        leftWaypointIndex = GameManager.instance.leftWaypointIndex;
        rightWaypointIndex = GameManager.instance.rightWaypointIndex;
        transform.position = waypoints[GameManager.instance.initialWaypointIndex].position;
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }
    #endregion
    */
    private void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
        myAnim = GetComponent<Animator>();
        InitializeWaypoints();
    }
    public void InitializeWaypoints()
    {
        Debug.Log("left waypoint: " + leftWaypointIndex);
        Debug.Log("right waypoint: " + rightWaypointIndex);
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }
    private void Update()
    {
        if (!performingAction)
        {
            if (Input.GetButtonDown("Action") && focus != null)
            {
                focus.GetComponent<Interactable>().Interact();
                inventory.CloseInventory();
            }
            if (Input.GetKeyDown(KeyCode.I) && canUseInventory)
            {
                inventory.InventoryTrigger();
            }
            if (actionItem != null)
            {
                if (Input.GetButtonDown("UseItem"))
                {
                    actionItem.Action();

                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    EquipmentManager.instance.Remove((int)actionItem.equipmentSlot);
                    inventory.CloseInventory();
                    actionItem = null;
                }
            }
        }
        
    }
    
    void FixedUpdate () {
        if (!performingAction)
        {
            Move();
        }
	}
    private void Move()
    {
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            myAnim.SetTrigger("Run");
            MoveRight();
            //set new waypoints
            if (transform.position == rightWaypoint.position && rightWaypointIndex < waypoints.Length - 1)
            {
                SetWaypointsRight();
                if (!rightWaypoint.gameObject.activeSelf)
                {
                    SetWaypointsLeft();
                }

            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            myAnim.SetTrigger("Run");
            MoveLeft();
            //set new waypoints
            if (transform.position == leftWaypoint.position && leftWaypointIndex > 0)
            {
                SetWaypointsLeft();
                if (!leftWaypoint.gameObject.activeSelf)
                {
                    SetWaypointsRight();
                }
            }
        }
        else
        {
            myAnim.SetTrigger("Idle");
        }
    }
    private void MoveLeft()
    {
        transform.position = Vector2.MoveTowards(transform.position, leftWaypoint.position, Time.deltaTime * moveSpeed * runMultiplayer);
        if (facingRight)
        {
            Flip();
        }
    }
    private void MoveRight()
    {
        transform.position = Vector2.MoveTowards(transform.position, rightWaypoint.position, Time.deltaTime * moveSpeed * runMultiplayer);
        if (!facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

    
    }

    private void SetWaypointsLeft()
    {
        rightWaypointIndex = leftWaypointIndex;
        leftWaypointIndex--;
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }
    private void SetWaypointsRight()
    {
        leftWaypointIndex = rightWaypointIndex;
        rightWaypointIndex++;
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }
    public void SetFocus(GameObject newFocus)
    {
        if (focus == null)
        {
            focus = newFocus;
            newFocus.GetComponent<Interactable>().isFocus = true;
        }
        else
        {
            if (newFocus == null)
            {
                focus = null;
            }
        }
    }

    public void SetPerformingAction(bool b)
    {
        
        if (b)
        {
            inventory.CloseInventory();
            canUseInventory = false;
            performingAction = true;

        }
        else
        {
            performingAction = false;
            canUseInventory = true;
        }
        myAnim.SetTrigger("Idle");


    }

    
}
