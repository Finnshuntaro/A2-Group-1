using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myCube;

    public void SpawnCube()
    {
        Instantiate(myCube);
    }
}
