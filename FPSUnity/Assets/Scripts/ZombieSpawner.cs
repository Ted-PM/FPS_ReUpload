using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;
    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;

    int waveCount;

    private void Awake()
    {
        Instance = this;
        waveCount = 1;
    }

    //private void Start()
    //{
    //    SpawnWaveOfZombies();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        SpawnWaveOfZombies();
    //    }

    //    //CountZombies();
    //}

    void SpawnWaveOfZombies()
    {
        waveCount++;
        HUD.Instance.UpdateWaveUI(waveCount);
        int spawnChoice = Random.Range(0, spawnPoints.Count);
        int temp = spawnChoice;

        for (int i = 0; i < waveCount; i++ )
        {
            spawnChoice = Random.Range(0, spawnPoints.Count);

            while (spawnChoice == temp)
            {
                spawnChoice = Random.Range(0, spawnPoints.Count);
            }

            Instantiate(zombiePrefab, spawnPoints[spawnChoice].position, transform.rotation, transform);
            temp = spawnChoice;
            
        }

        
    }

    public void CountZombies()
    {
        //Zombie[] allZombiesInScene = FindObjectsByType<Zombie>(FindObjectsSortMode.None);
        Zombie[] allZombiesInScene = FindObjectsOfType<Zombie>();

        //int numberOfZombies = allZombiesInScene.Length;

        if (allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }

        //if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
        //{
        //    SpawnWaveOfZombies();
        //}
        
    }
}