using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Door door;

    void OnMouseDown()
    {
        door.TryOpenDoor();
    }
}
