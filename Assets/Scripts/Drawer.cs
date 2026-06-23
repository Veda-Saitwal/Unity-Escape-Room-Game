using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Vector3 slideOffset = new Vector3(0, 0, 0.5f); // distance & direction
    public float speed = 2f;

    Vector3 startPos;
    Vector3 targetPos;
    bool slidingOut = false;

    void Start()
    {
        startPos = transform.localPosition;   // local keeps movement relative to parent
        targetPos = startPos;
    }

    void OnMouseDown() // Unity built-in: fires when you click this object
    {
        slidingOut = !slidingOut;
        targetPos = slidingOut ? startPos + slideOffset : startPos;
        Debug.Log(name + " toggled");
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            targetPos,
            speed * Time.deltaTime);
    }
}
