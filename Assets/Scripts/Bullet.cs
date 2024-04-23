using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] Bullet bullet;

    public void Fire(Player player)
    {
        
        if (player.scanner.nearestTarget == null) return;

        Vector3 targetpos = player.scanner.nearestTarget.position;
        Vector3 dir = targetpos - player.transform.position;
        dir = dir.normalized;
        bullet.transform.forward = Vector3.Lerp(transform.forward, dir, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var controller = collision;
        if(controller != null)
        {
            Monster.monsterHP -= 1;
        }
        Destroy(this.gameObject);
    }
}
