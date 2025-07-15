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

    void Start()
    {
        // playerMovement = FindObjectOfType<PlayerMovement>();
        // FindObjectOfType is slower and got deprecated (not supported in 2022+ versions of Unity)
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
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
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
    }
}
