using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public GameObject wind;

    public float accelerat = 30f;
    public float topspeed = 50f;

    ArcadeKart arcadeKart;

    private void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Accelerator")
        {
            StartCoroutine(Acceler(1.5f));
        }
    }

    IEnumerator Acceler(float delay)
    {
        GameObject a=Instantiate(wind, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        a.transform.parent = this.transform;
        a.transform.localPosition = new Vector3(0, 0, -1);
        a.transform.localRotation = new Quaternion(-180, 0, 0, 0);
        arcadeKart.baseStats.Acceleration = accelerat;
        arcadeKart.baseStats.TopSpeed = topspeed;
        yield return new WaitForSeconds(delay);
        arcadeKart.baseStats.Acceleration = 10;
        arcadeKart.baseStats.TopSpeed = 15;
        Destroy(a);
    }
}
