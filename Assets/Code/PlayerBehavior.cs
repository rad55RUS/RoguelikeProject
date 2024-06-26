using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CreatureBehavior
{
    /// <summary>
    /// is called before the first frame update
    /// </summary>
    protected override void OnStart()
    {
        base.OnStart();
    }

    /// <summary>
    /// is called once per frame
    /// </summary>
    protected override void OnUpdate()
    {
        base.OnUpdate();
    }

    /// <summary>
    /// is called every physics step
    /// </summary>
    protected override void OnFixedUpdate()
    {
        // Get input axis
        moveX = Input.GetAxis("Horizontal");  // -1 is Left; +1 is Right 
        moveY = Input.GetAxis("Vertical");    // -1 is Down; +1 is Up 

        // Check run key
        isRunning = Input.GetKey(KeyCode.LeftShift);

        base.OnFixedUpdate();
    }
}
