using UnityEngine;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectToGenerate;
    public float maxDistance = 10f;
    public float minDistance = 2f;
    public float yCoordinate = 1f;
    public float initialSpawnRate = 1f;
    public float spawnRateIncrease = 0.1f;
    public float maxSpawnTime = 30f;

    private float spawnRate;
    private float spawnTimer;
    private float elapsedTime;
    private List<GameObject> generatedObjects;
    private StartTheGame startTheGameScript;
    public ScoreCounter scoreCounter;

    void Start()
    {
        spawnRate = initialSpawnRate;
        spawnTimer = 0f;
        elapsedTime = 0f;
        generatedObjects = new List<GameObject>();
        startTheGameScript = Object.FindFirstObjectByType<StartTheGame>();
    }

    void Update()
    {
        //Debug.Log("elapsedTime: " + elapsedTime);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= maxSpawnTime)
        {
            DestroyGeneratedObjects();
            startTheGameScript.isGameRunning = false;
            elapsedTime = 0f; // Reset elapsedTime
            spawnTimer = 0f; // Reset spawnTimer
            scoreCounter.ResetScore(); // Reset score
            gameObject.SetActive(false); // Deactivate the entire GameObject
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            GenerateObject();
            spawnTimer = 0f;
            spawnRate = Mathf.Max(0.1f, spawnRate - spawnRateIncrease);
        }
    }

    void GenerateObject()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 spawnPosition;

        do
        {
            float x = Random.Range(-maxDistance, maxDistance);
            float z = Random.Range(-maxDistance, maxDistance);
            spawnPosition = new Vector3(cameraPosition.x + x, yCoordinate, cameraPosition.z + z);
        } while (Vector3.Distance(cameraPosition, spawnPosition) < minDistance);

        GameObject newObject = Instantiate(objectToGenerate, spawnPosition, Quaternion.identity);
        newObject.tag = "Balls"; // Set the tag here
        generatedObjects.Add(newObject);
    }

    public void DestroyGeneratedObjects()
    {
        foreach (GameObject obj in generatedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        generatedObjects.Clear();
    }
}