using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBehaviour))]
public class AnimationControllerBehaviour : MonoBehaviour
{
    [SerializeField]
    bool facingRight;

    Animator myAnim;
    InputBehaviour input;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        input = GetComponent<InputBehaviour>();
    }

    private void Update()
    {
        myAnim.SetFloat("hsp", Mathf.Abs(input.Horizontal));
        HandleFlipping();
    }

    private void HandleFlipping()
    {
        if (input.Horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (input.Horizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
