using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SnapZone2 : MonoBehaviour
{
    public GameObject slot;
    public GameObject foodSlot;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Knife")
        {
            col.gameObject.transform.position = slot.transform.position;
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            col.gameObject.transform.rotation = slot.transform.rotation;
        }
        else if (col.gameObject.name.Contains("Tomato") || col.gameObject.name.Contains("Onion"))
        {
        col.gameObject.transform.position = foodSlot.transform.position;
        col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        col.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        col.gameObject.GetComponent<Rigidbody>().useGravity = false;
        col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        col.gameObject.GetComponent<Collider>().isTrigger = true;
        
        }
    }
}
