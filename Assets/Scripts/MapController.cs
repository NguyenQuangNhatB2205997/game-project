using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement playerMovement;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    public GameObject latestChunk;
    public float maxOptimizeDistance; // must be greater than the length and width of the tilemap
    float OptimizeDistance;

    // cooldown for the optimizer to run
    // because the optimizer runs every frame and takes a lot of performance
    float optimizerCooldown;
    public float optimizerCooldownTime; // time in seconds before the optimizer runs again 
    // set to 1 as 1 second cooldown 
    
    void Start()
    {
        // playerMovement = FindObjectOfType<PlayerMovement>();
        // FindObjectOfType is slower and got deprecated (not supported in 2022+ versions of Unity)
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        // check if there is a terrain chunk
        if (!currentChunk)
        {
            return;
        }

        if (playerMovement.movement.x > 0 && playerMovement.movement.y == 0) // right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x < 0 && playerMovement.movement.y == 0) // left
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x == 0 && playerMovement.movement.y > 0) // up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x == 0 && playerMovement.movement.y < 0) // down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position + new Vector3(0, -20, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x > 0 && playerMovement.movement.y > 0) // right up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Up").position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x > 0 && playerMovement.movement.y < 0) // right down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x < 0 && playerMovement.movement.y > 0) // left up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }
        else if (playerMovement.movement.x < 0 && playerMovement.movement.y < 0) // left down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    // instead of destroying chunks, we just disable them to save performance
    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownTime;
        }
        else
        {
            return; // skip optimization if cooldown is not finished
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            OptimizeDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (OptimizeDistance > maxOptimizeDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
