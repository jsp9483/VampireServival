using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    public float speed = 10.0f;
    Monster monster;
    Player player;
    [SerializeField] Bullet bullet;

    public void Fire()
    {
        Vector3 targetpos = player.scanner.nearestTarget.position;
        Vector3 dir = targetpos - player.transform.position;
        dir = dir.normalized;
        bullet.transform.Translate(dir * Time.deltaTime * speed);
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
