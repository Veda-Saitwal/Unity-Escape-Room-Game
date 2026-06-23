using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("References")]
    public Keypad keypad;              // drag the Keypad parent here
    public KeyPickup keyPickup;
    public PlayerInventory playerInv;  // drag the Player object here

    [Header("Movement Settings")]
    public Vector3 openOffset = new Vector3(0, 0, -1.2f); // direction/amount to slide
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        targetPosition = closedPosition;
    }

    void Update()
    {
        // Continuously move toward target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * openSpeed);
    }

    public void TryOpenDoor()
    {
        // Called when player tries to open the door
        if (!isOpen && keypad.codeUnlocked && KeyPickup.hasKey)
        {
            isOpen = true;
            targetPosition = closedPosition + openOffset;
            Debug.Log("Door opened!");
        }
        else
        {
            if (!KeyPickup.hasKey) Debug.Log("You need the key.");
            if (!keypad.codeUnlocked) Debug.Log("PIN is incorrect.");
        }
    }
}
