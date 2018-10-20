using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //fields
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    float runMultiplayer = 1f; //may implement running
    [SerializeField]
    bool facingRight;
    [SerializeField]
    GameObject focus;

    [Header("Waypoints")]
    public Transform[] waypoints;
    public int leftWaypointIndex;
    public int rightWaypointIndex;

    Transform leftWaypoint;
    Transform rightWaypoint;
    public bool canUseInventory=true;
    public bool performingAction = false;
    public Equipment actionItem;
    Inventory inventory;
    Rigidbody2D myRb;
    Animator myAnim;
    float move;

    //properties
    public GameObject Focus 
    {
        get 
        {
            return focus; 
        }
        set 
        {
            if (focus == null)
            {
                focus = value;
                value.GetComponent<Interactable>().IsFocus = true;
            }
            else if (value ==null)
            {
                focus = null;
            }
        } 
    }


    //methods
    void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        InitializeWaypoints();
    }

    public void InitializeWaypoints()
    {
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }

    void Update()
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
                    //EquipmentManager.instance.Remove((int)actionItem.equipmentSlot);
                    inventory.CloseInventory();
                    actionItem = null;
                }
            }//if (actionItem != null)
        }//if (!performingAction)

    }


    void FixedUpdate () {
        move = Input.GetAxis("Horizontal");
        if (!performingAction)
        {
            Move();
            
        }
        else
        {
            myRb.velocity = Vector2.zero;
            move = 0;
        }

        myAnim.SetFloat("hsp", Mathf.Abs(move));
    }

    void Move()
    {
        
        float finalSpeed = Mathf.Abs(move) * moveSpeed;
        Vector2 dir;
        if (move > 0)
        {
            dir = (rightWaypoint.position - transform.position).normalized;
            if (!facingRight)
            {
                Flip();
            }
            //check waypoints
            if (Vector2.Distance(transform.position, rightWaypoint.position) < .1f )
            {
                if (rightWaypointIndex < waypoints.Length - 1)
                {
                    SetWaypointsRight();
                    if (!rightWaypoint.gameObject.activeSelf)
                    {
                        SetWaypointsLeft();
                    }
                }
                else
                {
                    finalSpeed = 0;
                }
            }
        }
        else if (move < 0)
        {
            dir = (leftWaypoint.position - transform.position).normalized;
            if (facingRight)
            {
                Flip();
            }
            //check waypoints
            if (Vector2.Distance(transform.position, leftWaypoint.position) < .1f)
            {
                if (leftWaypointIndex > 0)
                {
                    SetWaypointsLeft();
                    if (!leftWaypoint.gameObject.activeSelf)
                    {
                        SetWaypointsRight();
                    }
                }
                else
                {
                    finalSpeed = 0;
                }
            }
        }
        else
        {
            dir = Vector2.zero;
        }
        myRb.velocity = dir * finalSpeed;

       

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void SetWaypointsLeft()
    {
        rightWaypointIndex = leftWaypointIndex;
        leftWaypointIndex--;
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
    }
    void SetWaypointsRight()
    {
        leftWaypointIndex = rightWaypointIndex;
        rightWaypointIndex++;
        leftWaypoint = waypoints[leftWaypointIndex];
        rightWaypoint = waypoints[rightWaypointIndex];
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
    }

    
}
