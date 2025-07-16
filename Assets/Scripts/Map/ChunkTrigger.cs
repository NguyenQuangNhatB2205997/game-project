using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{

    MapController mapController;
    public GameObject targetMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapController = FindFirstObjectByType<MapController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Set the current chunk in MapController to this chunk
            mapController.currentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (mapController.currentChunk == targetMap)
            {
                // Reset the current chunk in MapController when the player exits this chunk
                mapController.currentChunk = null;
            }
        }
    }
}
