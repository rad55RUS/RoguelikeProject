using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatureBehavior : EntityBehavior
{
    // Public params
    /// Integers
    public int direction = 0;       // 0 - South; 1 - Southeast; 2 - East; 3 - Northeast; 4 - North; 5 - Northwest; 6 - West; 7 - Southwest
    public int jumpStrength = 1;    // Amount of tiles
    /// 
    /// Floats
    public float walkingSpeed = 4f;
    public float runningSpeed = 10f;
    public float speedMultiplier = 1f;
    ///
    // Protected params
    /// Booleans
    protected bool isRunning = false;
    protected bool isJumping = false;
    protected bool isDodging = false;
    protected bool isBlocking = false;
    protected bool isAttacking = false;
    protected bool isAiming = false;
    ///
    /// Floats
    protected float moveX = 0;  // -1 is Left; +1 is Right 
    protected float moveY = 0;  // -1 is Down; +1 is Up 
    protected float currentSpeed = 0;
    ///
    //

    /// Animation component
    private Animator animator;
    ///

    /// <summary>
    /// is called before the first frame update
    /// </summary>
    protected override void OnStart()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// is called once per frame
    /// </summary>
    protected override void OnUpdate()
    {
        
    }

    /// <summary>
    /// is called every physics step
    /// </summary>
    protected override void OnFixedUpdate()
    {
        animator.SetBool("isRunning", isRunning);

        // Setting current speed
        if (moveX != 0)
        {
            currentSpeed = moveX;
        }
        else if (moveY != 0)
        {
            currentSpeed = moveY;
        }

        if (isRunning)
        {
            currentSpeed *= runningSpeed * speedMultiplier;
        }
        else
        {
            currentSpeed *= walkingSpeed * speedMultiplier;
        }
        //

        SetDirection();
        GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed, GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
    }

    // Private methods
    private void SetDirection()
    {
        if (moveX > 0)
        {
            if (moveY > 0)
            {
                direction = 3;
            }
            else if (moveY < 0)
            {
                direction = 1;
            }
            else
            {
                direction = 2;
            }
        }
        else if (moveX < 0)
        {
            if (moveY > 0)
            {
                direction = 5;
            }
            else if (moveY < 0)
            {
                direction = 7;
            }
            else
            {
                direction = 6;
            }
        }
        else
        {
            if (moveY > 0)
            {
                direction = 4;
            }
            else if (moveY < 0)
            {
                direction = 0;
            }
        }
    }
    //
}
