using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public float spawnCooldown;
    private float currentSpawnCooldown;
    public int spawnX;
    public GameObject[] spawnPool;

    private void Awake()
    {
        currentSpawnCooldown = 0;
    }

    public void ManageSpawn()
    {
        if(currentSpawnCooldown <= 0)
        {
            SpawnRandom();
            currentSpawnCooldown = spawnCooldown;
        }
        else
        {
            currentSpawnCooldown -= Time.deltaTime;
        }
    }

    public void SpawnRandom()
    {
        var g = Instantiate(
            spawnPool[Random.Range(0, spawnPool.Length)],
            new Vector3(spawnX,Mage.mage.transform.position.y,0), 
            Quaternion.identity);
        g.GetComponent<Enemy>().SetLevel(Random.Range(1, GameManager.gm.gameLevel));
        GameManager.gm.activeEnemies.Add(g);
    }
}
