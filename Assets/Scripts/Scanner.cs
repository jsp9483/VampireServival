using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public Collider[] targets;
    public Transform nearestTarget;

    void FixedUpdate()
    {
        targets = Physics.OverlapSphere(
            transform.position,
            scanRange,
            targetLayer);
        
        //널인지 아닌지 확인
        //if()
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float distance = 100f;

        foreach(Collider target in targets)
        {
            //Debug.Log("target null = " + target == null );

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
