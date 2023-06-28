using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    public GameObject playerRightHand;
    public GameObject pickableObject;

    public float pickUpRange;
    public float dropForwardsForce, dropUpwardsForce;

    public bool equipped;
    public static bool slotFull;


    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }




    }

    public void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude < pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull) { 
            PickUp();
        }
        if (!equipped && distanceToPlayer.magnitude < pickUpRange && Input.GetKeyDown(KeyCode.F) && slotFull)
        {
            Drop();
        }
    }
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;


        rb.isKinematic = true;
        coll.isTrigger = true;

        pickableObject.transform.SetParent(playerRightHand.transform);
        pickableObject.transform.localScale = Vector3.one;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(fpsCam.forward * dropForwardsForce, ForceMode.Impulse);
        float rand = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(rand, rand, rand) * 10);

        rb.isKinematic = false;
        coll.isTrigger = false;
    }
   
}
