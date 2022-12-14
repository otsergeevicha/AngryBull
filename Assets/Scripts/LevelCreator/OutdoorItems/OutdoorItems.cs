using UnityEngine;

public class OutdoorItems : MonoBehaviour
{
    public Transform Position {get; private set;}

    public void Init(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }
}