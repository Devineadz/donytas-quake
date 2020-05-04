using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationShaker
{
    public TranslationShaker(Vector3 position, float magnitude, int numOfShakes, float shakeTime)
    {
        myPosition = position;
        myMagnitude = magnitude;
        myNumOfShakes = numOfShakes;
        myShakeTime = shakeTime;
        currentShake = numOfShakes;
    }

    private Vector3 myPosition;
    private float myMagnitude;
    private int myNumOfShakes;
    private float myShakeTime;

    private Vector3 offset = Vector3.zero;
    private int currentShake = 0;
    private float currentTime = 0f;

    private Vector3 shakeDirection = Vector3.left;
    public Vector3 getPosition() { return myPosition + offset; }

    public void shake() 
    {
        currentShake = 0; 
        currentTime = 0;
        shakeDirection = Quaternion.Euler(0, 0, Random.Range(0, 360)) * Vector3.left;
    }
    public void Update()
    {
        if (currentShake < myNumOfShakes)
        {
            currentTime += Time.deltaTime;
            while (currentTime > myShakeTime)
            {
                currentTime -= myShakeTime;
                ++currentShake;
                shakeDirection = Quaternion.Euler(0, 0, Random.Range(135, 215)) * shakeDirection;
            }
            offset += shakeDirection * myMagnitude * Time.deltaTime;
        }
        else
        {
            float offsetMagnitude = offset.magnitude;
            offset.Normalize();
            offset = offset * (Mathf.Max(0, offsetMagnitude - (myMagnitude * Time.deltaTime)));
        }
    }
}
