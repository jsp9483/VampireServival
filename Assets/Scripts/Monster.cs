using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static float monsterHP = 100f;
    public float speed = 1f;

    Rigidbody rigidbody;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector3 dirVec = Player.rigidbody.position - this.rigidbody.position;
        Vector3 nextVec = dirVec * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(this.rigidbody.position + nextVec);
        rigidbody.velocity = Vector3.zero;
        bool collider = rigidbody.CompareTag("Player");
        if(monsterHP < 0f) 
        {
            Destroy(gameObject);
        }
        if (collider == true)
        {
            Player.playerHP -= 1f;
        }
    }
}
