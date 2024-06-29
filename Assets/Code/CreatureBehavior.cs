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
    protected bool isDashing = false;
    protected bool isBlocking = false;
    protected bool isAttacking = false;
    protected bool isAiming = false;
    ///
    /// Floats
    protected float moveX = 0;  // -1 is Left; +1 is Right 
    protected float moveY = 0;  // -1 is Down; +1 is Up 
    protected float currentSpeedX = 0;
    protected float currentSpeedY = 0;
    ///
    //

    /// Animation component
    private Animator animator;
    private GameObject gameObject;
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
            currentSpeedX = moveX;
        }
        else
        {
            currentSpeedX = 0;
        }
        if (moveY != 0)
        {
            currentSpeedY = moveY;
        } 
        else
        {
            currentSpeedY = 0;
        }

        if (isRunning)
        {
            currentSpeedX *= runningSpeed * speedMultiplier;
            currentSpeedY *= runningSpeed * speedMultiplier;
        }
        else
        {
            currentSpeedX *= walkingSpeed * speedMultiplier;
            currentSpeedY *= walkingSpeed * speedMultiplier;
        }

        /// For animator
        if (currentSpeedX > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(currentSpeedX));
        }
        else if (currentSpeedY > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(currentSpeedY));
        }
        ///
        //

        SetDirection();
        

        GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeedX, currentSpeedY);
    }
    
    // Private methods
    private void SetDirection()
    {
        int oldDirection = direction;
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
        if (oldDirection != direction)
        {
            string directionName;
            bool facedRight = true;
            Vector3 localScale = transform.localScale;

            switch (direction)
            {
                case 0:
                    directionName = "South";
                    break;
                case 1:
                    directionName = "South";
                    break;
                case 2:
                    directionName = "Side";
                    facedRight = true;
                    break;
                case 3:
                    directionName = "North";
                    break;
                case 4:
                    directionName = "North";
                    break;
                case 5:
                    directionName = "North";
                    break;
                case 6:
                    directionName = "Side";
                    facedRight = false;
                    break;
                case 7:
                    directionName = "South";
                    break;
                default:
                    directionName = "South";
                    break;
            }

            if (facedRight)
            {
                if (localScale.x < 0)
                {
                    localScale.x *= -1;
                }
            }
            else
            {
                if (localScale.x > 0)
                {
                    localScale.x *= -1;
                }
            }
            transform.localScale = localScale;

            foreach (Transform child in transform)
            {
                if (child.gameObject.name == directionName)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
    //
}
