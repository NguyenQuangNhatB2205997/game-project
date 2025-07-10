using System.Collections.Generic;
using UnityEngine;

public class PropsRandomizer : MonoBehaviour
{

    public List<GameObject> propSwarmPoints; // List of prop spawn points; 
    public List<GameObject> propPrefabs; // List of prop prefabs to spawn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwarmProps(); // Call the SwarmProps method to spawn props at the designated points
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwarmProps()
    {
        foreach (GameObject sp in propSwarmPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count); // Get a random index from the propPrefabs list
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity); // Instantiate the random prop prefab at the spawn point's position
            prop.transform.SetParent(sp.transform); // Set the parent of the instantiated prop to the spawn point
        }
    }

}
