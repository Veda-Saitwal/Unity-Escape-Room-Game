using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public string interactionHint = "Press E to interact";

    // Accepts interactor (player) so subclasses can get player data
    public virtual void Interact(GameObject interactor)
    {
        Debug.Log(gameObject.name + " interacted with by " + interactor.name);
    }
}
