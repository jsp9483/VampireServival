using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManager : MonoBehaviour
{
    public GameObject monster;
    float timer = 0;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            CreateMonster();
        }
    }

    private void CreateMonster()
    {
        Vector3 pos = new Vector3(
            Random.Range(-100.0f, 100.0f),
            0,
            Random.Range(-100.0f, 100.0f));
        Instantiate(monster, pos, Quaternion.identity);
    }
}
