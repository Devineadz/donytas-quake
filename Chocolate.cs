using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Chocolate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
  
    }

    void OnDisable()
    {

    }

    public void chocolateDestroy()
    {
        Destroy(this.gameObject);
    }

}
