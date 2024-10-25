using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject grenadePrefab;
    public Transform projectileSpawnPoint;
    public Transform grenadeSpawnPoint;
    public float projectileLaunchSpeed;
    public float grenadeLaunchSpeed;
    public AudioSource shootSound;

    private int amoCount;

    private void Awake()
    {
        amoCount = 20;
    }
    // Start is called before the first frame update
    void Start()
    {
        HUD.Instance.UpdateAmoUI(amoCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (amoCount > 0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    void Shoot()
    {
        amoCount--;
        HUD.Instance.UpdateAmoUI(amoCount);
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
        shootSound.Play();
        Destroy(newProjectile, 5);
        //TODO Make sound effect
        
    }

    void ThrowGrenade()
    {
        //amoCount--;
        //HUD.Instance.UpdateAmoUI(amoCount);
        print("Throw");
        GameObject newGrenade = Instantiate(grenadePrefab, grenadeSpawnPoint.position, transform.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(grenadeSpawnPoint.forward * grenadeLaunchSpeed);
        newGrenade.GetComponent<Rigidbody>().AddForce(grenadeSpawnPoint.up * 100);
        shootSound.Play();
        Destroy(newGrenade, 5);
        //TODO Make sound effect
    }

    public void ReFillAmo()
    {
        if (amoCount <= 10)
        {
            amoCount += 10;
        }
        else
        {
            amoCount = 20;
        }

        HUD.Instance.UpdateAmoUI(amoCount);
    }
}
