using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hazelnut, cheese, chocolate;
    void OnEnable()
    {
        EventManager.StartListening("shake", shake);
    }

    void OnDisable()
    {
        EventManager.StopListening("shake", shake);
    }

    void shake()
    {
        Debug.Log("Dropping Hazelnut!");
        Instantiate(hazelnut, new Vector3(16, 19, -19), transform.rotation);

        Debug.Log("Dropping Cheese!");
        Instantiate(cheese, new Vector3(16, 19, -19), transform.rotation);

        Debug.Log("Dropping Chocolate!");
        Instantiate(chocolate, new Vector3(16, 19, -19), transform.rotation);

        Debug.Log("Dropping Hazelnut!");
        Instantiate(hazelnut, new Vector3(16, 19, -19), transform.rotation);

        Debug.Log("Dropping Cheese!");
        Instantiate(cheese, new Vector3(16, 19, -19), transform.rotation);

        Debug.Log("Dropping Chocolate!");
        Instantiate(chocolate, new Vector3(16, 19, -19), transform.rotation);

    }
}
