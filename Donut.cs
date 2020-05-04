using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Donut : MonoBehaviour
{
    public float speed;
    public int chocolate;
    public int hazelnut;
    public int hazelChoco;
    public int picks;
    public bool playerInTriggerChoco;
    public bool playerInTriggerHazel;
    private CharacterController controller;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection;
    public Text countHazelChoco;
    public Text countHazel;
    public Text countChoco;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        chocolate = 0;
        hazelnut = 0;
        hazelChoco = 0;
        picks = 0;
        SetCountText();
        SetChocoCount();
        playerInTriggerChoco = false;
        playerInTriggerHazel = false;
        jumpSpeed = 8.0F;
        gravity = 10.0F;
        moveDirection = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveDirection = Vector3.left * speed * Time.deltaTime;
            controller.Move(moveDirection);
        
            // transform.rotation?
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 move  = Vector3.right * speed * Time.deltaTime;
            controller.Move(move);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move  = Vector3.forward * speed * Time.deltaTime;
            controller.Move(move);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 move = Vector3.back * speed * Time.deltaTime;
            controller.Move(move);
        }
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            EventManager.TriggerEvent("shake");
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if (Input.GetKey(KeyCode.L) && playerInTriggerChoco==true)
        {
            EventManager.TriggerEvent("chocolateDestroy");
            picks++;
            if (chocolate == 0)
            {
                chocolate++;
            
            }
            else if(chocolate == 1)
            {
                chocolate--;
               
            }
            SetChocoCount();
            playerInTriggerChoco = false;
        }
        if (Input.GetKey(KeyCode.L) && playerInTriggerHazel == true)
        {
            picks++;
            if (hazelnut == 0)
            {
                hazelnut++;

            }
            else if (hazelnut == 1)
            {
                hazelnut--;
            }
            SetHazelCount();
            playerInTriggerHazel = false;
        }

        if (chocolate ==1 && hazelnut == 1)
        {
            chocolate--;
            hazelnut--;
            hazelChoco++;
            SetCountText();
            SetChocoCount();
            SetHazelCount();
        }

        if (hazelChoco == 3) // TODO Add victory screen
        {
            Debug.Log("You win!");
            SceneManager.LoadScene("Win");
        }

        if (picks == 14)
        {
            Debug.Log("You lose!"); // TODO Add Losing screen
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cheese")
        {
            other.gameObject.GetComponent<Cheese>().cheeseDestroy();

            picks++;
            if (chocolate == 1)
            {
                chocolate--;

            }
            else if (hazelnut == 1)
            {
                hazelnut--;

            }
            SetChocoCount();
        }
        if (other.gameObject.tag == "chocolate")
        {
            other.gameObject.GetComponent<Chocolate>().chocolateDestroy();
            picks++;
            if (chocolate == 0)
            {
                chocolate++;

            }
            else if (chocolate == 1)
            {
                chocolate--;
            }
            SetChocoCount();
            //playerInTriggerChoco = true;
        }
        if(other.gameObject.tag == "hazelnut")
        {
            picks++;
            if (hazelnut == 0)
            {
                hazelnut++;

            }
            else if (hazelnut == 1)
            {
                hazelnut--;
            }
            SetHazelCount();
            other.gameObject.GetComponent<Hazelnut>().hazelnutDestroy();
            //playerInTriggerHazel = true;
        }

    }

    void SetCountText()
    {
        countHazelChoco.text = "Count: " + hazelChoco.ToString();
    }

    void SetChocoCount()
    {
        countChoco.text = "Chocolates: " + chocolate.ToString();
    }

    void SetHazelCount()
    {
        countHazel.text = "Hazelnuts: " + hazelnut.ToString();
    }
}
