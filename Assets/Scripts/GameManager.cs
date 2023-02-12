using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawn;
    public int startEats;
    public float eatsDelay;
    public void GenerateEat()//создаём кусок еды
    {
        Instantiate(spawn, new Vector2(Random.Range(-28.5f, 28.5f), Random.Range(-19f, 19f)), Quaternion.identity);
    }

    public void Start()
    {
        InvokeRepeating("GenerateEat", eatsDelay, eatsDelay);
        for (int i = 0; i < startEats; i++)
        {
            GenerateEat();
        }
    }
}
