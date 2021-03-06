using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public GameObject[] interactables;
    public int amountOfInteractables;
    public Text interactableText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks and displays the number of Interactable items are in the scene
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        amountOfInteractables = interactables.Length;
        interactableText.text = "Tasks Remaining: " + amountOfInteractables;
        //Changes to win scene when the number of interactables in equal to zero
        if (amountOfInteractables <= 0)
        {
            SceneManager.LoadScene("Win");
        }

    }
}
