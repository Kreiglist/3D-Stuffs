using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGame : MonoBehaviour
{
    [SerializeField] GameObject cube;
    GameObject cubeInstance;
    private List<GameObject> instantiatedCubes = new List<GameObject>(); // List to store all spawned cubes
    public void SummonCube()
    {
        cubeInstance = Instantiate(cube);
        instantiatedCubes.Add(cubeInstance);  // Add the newly instantiated cube to the list for tracking
    }
    public void ChangeCubeColor()
    {
        // If no cubes have been instantiated, exit the function
        if (instantiatedCubes.Count == 0) return;

        // Randomly generate a new color
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

        // Loop through all instantiated cubes and change their material color
        foreach (GameObject cube in instantiatedCubes)
        {
            Renderer objrend = cube.GetComponent<Renderer>();
            if (objrend != null)
            {
                objrend.material.color = newColor;
            }
        }
    }
    public void ChaosCubeColor()
    {
        if (instantiatedCubes.Count == 0) return;

        // Loop through all instantiated cubes and change their material color
        foreach (GameObject cube in instantiatedCubes)
        {
            float chaosColorR = Random.Range(0f, 1f);
            float chaosColorG = Random.Range(0f, 1f);
            float chaosColorB = Random.Range(0f, 1f);
            Renderer objrend = cube.GetComponent<Renderer>();
            if (objrend != null)
            {
                objrend.material.color = new Color(chaosColorR, chaosColorG, chaosColorB, 1f);
            }
        }
    }
    public void ChangeCubeSize()
    {
        if (instantiatedCubes.Count == 0) return;

        float RandomX = Random.Range(0.5f, 2f);
        float RandomY = Random.Range(0.5f, 2f);
        float RandomZ = Random.Range(0.5f, 2f);
        Vector3 newScale = new Vector3(RandomX, RandomY, RandomZ);

        foreach (GameObject cube in instantiatedCubes)
        {
            cube.transform.localScale = newScale;
        }
    }
    public void ChaosCubeSize()
    {
        if (instantiatedCubes.Count == 0) return;

        foreach (GameObject cube in instantiatedCubes)
        {
            float ChaosX = Random.Range(0.5f, 2f);
            float ChaosY = Random.Range(0.5f, 2f);
            float ChaosZ = Random.Range(0.5f, 2f);

            cube.transform.localScale = new Vector3(ChaosX, ChaosY, ChaosZ);
        }
    }
}