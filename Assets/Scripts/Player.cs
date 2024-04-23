using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Rigidbody rigidbody;
    public float speed = 10f;
    public float rotSpeed = 10f;
    public static float playerHP = 100f;
    public float playerMaxHP = 100f;
    public Scanner scanner;
    private Vector3 dir = Vector3.zero;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        scanner = GetComponent<Scanner>();
    }

    private void Start()
    {
        playerHP = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        Debug.Log("PlayerHP = " + playerHP);

        if(playerHP <= 0)
        {
            playerHP = 100f;
            GameOver();
        }

    }

    private void FixedUpdate()
    {
        // 지금 바라보는 방향의 부호 != 나아갈 방향 부호
        if(dir != Vector3.zero)
        {
            if(Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward,dir, rotSpeed*Time.deltaTime);
        }

        rigidbody.MovePosition(gameObject.transform.position + dir * speed * Time.deltaTime);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Play");
    }

}
