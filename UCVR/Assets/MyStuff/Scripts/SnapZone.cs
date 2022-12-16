using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SnapZone : MonoBehaviour
{
    public GameObject slot;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Knife")
        {}
        else
        {
        col.gameObject.transform.position = slot.transform.position;
        col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        col.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
