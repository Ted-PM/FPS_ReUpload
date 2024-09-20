using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileLaunchSpeed;
    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
        shootSound.Play();
        Destroy(newProjectile, 5);
        //TODO Make sound effect
    }
}
