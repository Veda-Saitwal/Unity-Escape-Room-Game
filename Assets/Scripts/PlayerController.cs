using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 4f;
    public float lookSensitivity = 2f;

    [Header("Interaction")]
    public float interactRange = 5f;
    public Camera playerCamera;   // drag MainCamera (child of Player)

    CharacterController controller;
    float pitch = 0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   // lock cursor to centre
    }

    void Update()
    {
        Move();
        Look();
        CheckClickInteract();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.SimpleMove(move * moveSpeed);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        if (playerCamera)
            playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void CheckClickInteract()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse click
        {
            Ray ray = playerCamera.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Interactable interact = hit.collider.GetComponent<Interactable>();
                if (interact != null)
                {
                    Debug.Log("Clicked on " + hit.collider.name);
                    interact.Interact(gameObject);
                }
            }
        }
    }
}
