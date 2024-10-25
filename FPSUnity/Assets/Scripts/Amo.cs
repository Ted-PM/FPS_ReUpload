using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
public class Amo : MonoBehaviour
{

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<FPSController>())
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AmoCollide");
        if (collision.gameObject.GetComponent<FPSController>())
        {
            Debug.Log("pLAYER AmoCollide");
            Cannon.FindObjectOfType<Cannon>().ReFillAmo();
            //Destroy(gameObject);
            AmoSpawner.Instance.SpawnAgain(gameObject.transform.position);
            Destroy(gameObject);
        }

    }
}
