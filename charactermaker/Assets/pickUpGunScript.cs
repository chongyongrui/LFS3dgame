using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject gunToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand
    
    
    List<GameObject> list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKeyDown(KeyCode.F) && hasItem == false)  
            {
                gunToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                gunToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                gunToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
                BoxCollider[] bc = gunToPickUp.GetComponents<BoxCollider>();
                bc[0].enabled = false;

                Quaternion myRotation = Quaternion.identity;
                myRotation.eulerAngles = new Vector3(-7.5f, 172, -260);
                gunToPickUp.transform.rotation = myRotation;
                //list.Add(gunToPickUp);
                
            }


        }
        
        if (Input.GetKeyDown(KeyCode.G) && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
        {
            gunToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

            gunToPickUp.transform.parent = null; // make the object no be a child of the hands
            hasItem = false;

            BoxCollider[] bc = gunToPickUp.GetComponents<BoxCollider>();
            bc[0].enabled = true;


        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        Debug.Log("Picakable object found");
        if (other.gameObject.tag == "pickableobject") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            gunToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            Debug.Log("Picakable object found");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false

    }
}