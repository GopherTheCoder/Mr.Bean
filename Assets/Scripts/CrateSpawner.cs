using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public float spawnDelay;
    public float leftBoundary, rightBoundary;
    public GameObject healthCrate, ammoCrate;
    [HideInInspector]
    public bool crateExist;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Hero").GetComponent<PlayerHealth>();
        StartCoroutine(SpawnCrate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SpawnCrate()
    {
        yield return new WaitForSeconds(spawnDelay);

        if (!crateExist)
        {
            if (playerHealth.health <= 25)
                Instantiate(healthCrate, new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y), Quaternion.identity);
            else if (playerHealth.health >= 100)
                Instantiate(ammoCrate, new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y), Quaternion.identity);
            else
            {
                float t = Random.value;
                if (t > 0.5) Instantiate(healthCrate, new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y), Quaternion.identity);
                else Instantiate(ammoCrate, new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y), Quaternion.identity);
            }
            crateExist = true;
        }
    }
}
