using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AmoSpawner : MonoBehaviour
{

    public static AmoSpawner Instance;
    public GameObject amoPrefab;
    public List<Transform> spawnPoints;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnAmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAmo()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Instantiate(amoPrefab, spawnPoints[i].position, transform.rotation, transform);
        }
    }

    public void SpawnAgain(Vector3 pos)
    {
        StartCoroutine(Wait30(pos));
        //Instantiate(amoPrefab, pos, transform.rotation, transform);

    }

    private IEnumerator Wait30(Vector3 pos)
    {

        yield return new WaitForSeconds(30);
        Instantiate(amoPrefab, pos, transform.rotation, transform);
    }
}
