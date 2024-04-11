using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit[] targets;
    public Transform nearestTarget;
    void FixedUpdate()
    {
        targets = Physics.SphereCastAll(
            transform.position, 
            scanRange, 
            Vector3.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float distance = 100f;

        foreach(RaycastHit target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float currentDistance = Vector3.Distance(myPos, targetPos);

            if(distance > currentDistance)
            {
                distance = currentDistance;
                result = target.transform;
            }
        }

        return result;
    }
}
