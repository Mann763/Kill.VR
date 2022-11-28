using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onTargetReached : MonoBehaviour
{
    public float threshold = 0.02f;
    public Transform target;
    public UnityEvent OnReached;
    private bool wasReached;

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < threshold && !wasReached)
        {
            OnReached.Invoke();
            wasReached = true;
        }
        else if(distance >= threshold)
        {
            wasReached = false;
        }
    }
}
