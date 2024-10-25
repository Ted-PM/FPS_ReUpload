using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed;
    public float damageToGive;
    public float dammageRadius;

    public GameObject boomPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Zombie>())
        //{
        //    collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);

        //}
        Instantiate(boomPrefab, transform.position, Quaternion.identity, null);
        Expload(gameObject.transform.position, dammageRadius);

        Destroy(gameObject);

    }

    private void Expload(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.GetComponent<Zombie>())
            {
                hitCollider.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
            }
            //hitCollider.SendMessage("AddDamage");
        }
    }


}
