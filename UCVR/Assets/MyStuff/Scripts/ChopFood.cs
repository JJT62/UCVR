using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ChopFood : MonoBehaviour
{
    public GameObject food;
    private int chops = 0;
    private bool chopEnd = true;
    public GameObject prefab;
    void OnCollisionEnter(Collision col)
    {
        if (chopEnd == true && chops < 7)
        {
            chops += 1;
            chopEnd = false;
            Debug.Log("Chops: " + chops);
        }
        else if (chopEnd == true && chops >= 7)
        {
            GameObject planting = GameObject.Instantiate<GameObject>(prefab);
            planting.transform.position = this.transform.position;
            planting.transform.rotation = Quaternion.Euler(0, 0, 0);
            Rigidbody rigidbody = planting.GetComponent<Rigidbody>();
            if (rigidbody != null)
                rigidbody.isKinematic = true;

            StartCoroutine(ScaleOverTime(planting, Vector3.one * 0.6f, Vector3.one * 0.65f, 0.1f));

            if (rigidbody != null)
                rigidbody.isKinematic = false;

            chopEnd = false;
            Destroy(food);
        }
    }

    void OnCollisionEnd(Collision col)
{
    if (chopEnd == false)
    {
        chopEnd = true;
    }
}

    IEnumerator ScaleOverTime(GameObject planting, Vector3 initialScale, Vector3 targetScale, float overTime)
    {
        float startTime = Time.time;
        float endTime = startTime + overTime;

        while (Time.time < endTime)
        {
            planting.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
            yield return null;
        }
    }
}
