using UnityEngine;
using TMPro;   // If using TextMeshPro

public class Keypad : MonoBehaviour
{
    [Header("UI")]
    public TextMeshPro display;   // drag Display text object
    public TextMeshPro hintText;  // drag Hint text object

    [Header("Settings")]
    public string correctPin = "2580";
    public string pinHint = "Hint: Middle numbers on a phone keypad!";

    [HideInInspector] public bool codeUnlocked = false;

    private string input = "";

    void Start()
    {
        // show initial hint
        if (hintText) hintText.text = pinHint;
        if (display) display.text = "";
    }

    public void PressNumber(string num)
    {
        if (codeUnlocked) return; // already solved
        if (input.Length < correctPin.Length)
        {
            input += num;
            if (display) display.text = input;
        }
    }

    public void ClearInput()
    {
        if (codeUnlocked) return;
        input = "";
        if (display) display.text = "";
    }

    public void Enter()
    {
        if (codeUnlocked) return;

        if (input == correctPin)
        {
            codeUnlocked = true;
            if (display) display.text = "?";
            if (hintText) hintText.text = "Door unlocked!";
            Debug.Log("Correct PIN entered!");
        }
        else
        {
            if (hintText) hintText.text = "Wrong code, try again.";
            input = "";
            if (display) display.text = "";
        }
    }
}
