using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform hinge;            // rotate this transform
    public float openAngle = 90f;
    public float speed = 3f;
    public bool locked = true;

    [HideInInspector] public bool playerIsInside = false;

    Quaternion closedRot;
    Quaternion targetRot;
    bool moving = false;

    void Start()
    {
        if (hinge == null) hinge = transform;
        closedRot = hinge.localRotation;
    }

    public void UnlockAndOpen()
    {
        locked = false;
        OpenBasedOnInside();
    }

    public void OpenBasedOnInside()
    {
        if (locked || moving) return;
        float angle = playerIsInside ? -openAngle : openAngle; // negative to open inward (customize)
        targetRot = closedRot * Quaternion.Euler(0, angle, 0);
        StopAllCoroutines();
        StartCoroutine(RotateTo(targetRot));
    }

    IEnumerator RotateTo(Quaternion target)
    {
        moving = true;
        float t = 0f;
        Quaternion start = hinge.localRotation;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            hinge.localRotation = Quaternion.Slerp(start, target, t);
            yield return null;
        }
        moving = false;
    }
}
