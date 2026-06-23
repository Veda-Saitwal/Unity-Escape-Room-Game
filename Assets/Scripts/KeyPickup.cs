using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    // Global flag – other scripts can check KeyPickup.hasKey
    public static bool hasKey = false;

    void OnMouseDown()
    {
        hasKey = true;
        Debug.Log("Key picked up!");
        gameObject.SetActive(false);   // hides the key from the scene
    }
}
