using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBehavior : MonoBehaviour
{
    // Abstract methods
    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract void OnFixedUpdate();
    //

    /// <summary>
    /// is called before the first frame update
    /// </summary>
    private void Start()
    {
        OnStart();
    }

    /// <summary>
    /// is called once per frame
    /// </summary>
    private void Update()
    {
        OnUpdate();
    }

    /// <summary>
    /// is called every physics step
    /// </summary>
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
