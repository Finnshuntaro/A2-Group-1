using UnityEngine;

public class ButtonDelete : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name + " to delete cubes");

        foreach (GameObject cube in ButtonCreate.spawnedCubes)
        {
            if (cube != null)
            {
                Destroy(cube);
            }
        }

        // Clear the list afterward
        ButtonCreate.spawnedCubes.Clear();
    }
}
