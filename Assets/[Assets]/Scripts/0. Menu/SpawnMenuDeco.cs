using System.Collections;
using UnityEngine;

public class SpawnMenuDeco : MonoBehaviour
{
    [SerializeField] GameObject decoPrefab;
    [SerializeField] private float spawnInterval;

    private GameObject decoInstance;
    void Start()
    {
        StartCoroutine(SpawnStuffs(spawnInterval));
    }

    private void CubeRandomizer()
    {
        // Random Location
        float randomLocations = Random.Range(-5f, 5f);
        Vector3 randomPosition = new Vector3(randomLocations, 0, randomLocations);
        // Random Rotation
        int randomRotationX = Random.Range(0, 360); int randomRotationY = Random.Range(0, 360); int randomRotationZ = Random.Range(0, 360);
        Quaternion randomQuaternion = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
        // Random Scale
        float randomSizeX = Random.Range(0.5f, 2f); float randomSizeY = Random.Range(0.5f, 2f); float randomSizeZ = Random.Range(0.5f, 2f);
        Vector3 randomScale = new Vector3(randomSizeX, randomSizeY, randomSizeZ);
        // Random Color
        float randomR = Random.Range(0f, 1f); float randomG = Random.Range(0f, 1f); float randomB = Random.Range(0f, 1f);

        decoInstance = Instantiate(decoPrefab, transform.position + randomPosition, randomQuaternion);
        decoInstance.transform.localScale = randomScale;
        decoInstance.GetComponent<MeshRenderer>().material.color = new Color(randomR, randomG, randomB, 1f);
    }
    private IEnumerator SpawnStuffs(float interval)
    {
        while (true)
        {
            CubeRandomizer();
            yield return new WaitForSeconds(interval);
        }
    }
}
