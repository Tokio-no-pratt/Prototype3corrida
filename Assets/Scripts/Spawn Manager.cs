using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private float startDaley = 2;
    private float repeatRate = 2;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDaley, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
      
    }

    // Update is called once per frame
    void Update()
    {
       //Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation); 
    }

    void SpawnObstacle()
    {
         if (playerControllerScript.gameOver == false)
         {
         Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation); 
         }
    }
}


