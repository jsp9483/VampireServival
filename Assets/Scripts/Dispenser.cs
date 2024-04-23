using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject bulletPrefab;
    Player player;
    float delay = 1f;
    float timer;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= delay )
        {
            var bullet = Instantiate( bulletPrefab, transform.position, Quaternion.identity ).GetComponent<Bullet>();
            bullet.Fire(player);
            timer = 0f;
        }
    }
}
