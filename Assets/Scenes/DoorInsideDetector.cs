using UnityEngine;

public class DoorInsideDetector : MonoBehaviour
{
    public DoorController door;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) door.playerIsInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) door.playerIsInside = false;
    }
}
