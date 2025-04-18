using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuDeco : MonoBehaviour
{
    [SerializeField] GameObject decoPrefab;
    void Start()
    {
        Instantiate(decoPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
