using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DeleteZone : MonoBehaviour
{
    public GameObject slot;
    void OnCollisionEnter(Collision col)
    {
        if( col.gameObject.name.Contains("Tomato") || col.gameObject.name.Contains("Onion") )
        {
            Destroy(col.gameObject);
        }
    }
}
