using System.Collections.Generic;
using UnityEngine;

public class ButtonCreate : Interactable
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private Transform spawnPoint;

    // Static list of all spawned cubes
    public static List<GameObject> spawnedCubes = new List<GameObject>();

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.forward;
        GameObject newCube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

        spawnedCubes.Add(newCube);
    }
}
