using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Camera : MonoBehaviour
{
    TranslationShaker translationShaker;
    void Awake()
    {
        translationShaker = new TranslationShaker(transform.position, 5f, 10, 0.15f);
    }

    void OnEnable()
    {
        EventManager.StartListening("shake", shake);
    }

    void OnDisable()
    {
        EventManager.StopListening("shake", shake);
    }

    private void Update()
    {
        translationShaker.Update();
        transform.position = translationShaker.getPosition();
    }

    void shake()
    {
        Debug.Log("Shaking camera!");
        translationShaker.shake();
    }
}
