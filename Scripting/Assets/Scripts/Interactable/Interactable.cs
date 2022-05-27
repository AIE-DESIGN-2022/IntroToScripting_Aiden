using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool playerCollided;
    public GameObject interactPrompt;
    public GameObject theSpookySkeleton;
    public float currentProgress;
    public float maxProgess;
    public Slider progressBar;
    public bool interacting;
    // Start is called before the first frame update
    void Start()
    {
        interactPrompt = GameObject.FindGameObjectWithTag("InteractPrompt").gameObject;
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player").gameObject;
        currentProgress = 0;
        progressBar.maxValue = maxProgess;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollided == true)
        {
            interactPrompt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                theSpookySkeleton.GetComponent<Skeleton>().interacting = true;
                interacting = true;
                currentProgress += Time.deltaTime;
            }
            else
            {
                theSpookySkeleton.GetComponent<Skeleton>().interacting = false;
                interacting = false;
            }
            UpdateProgressBar();

        }
        else if (playerCollided == false)
        {
            //MAKE SKELETON STOP INTERACTING ONCE THIS IS DESTROYED
            theSpookySkeleton.GetComponent <Skeleton>().interacting = false;
            interactPrompt.SetActive(false);
            UpdateProgressBar();
        }
        if (interacting == false)
        {
            currentProgress -= Time.deltaTime;
        }
        if (currentProgress <= 0)
        {
            currentProgress = 0;
            progressBar.gameObject.SetActive(false);
        }
        if (currentProgress >= maxProgess)
        {
            interactPrompt.SetActive(false);
            Destroy(gameObject);
        }
        if (currentProgress > 0)
        {
            progressBar.gameObject.SetActive(true);
        }
    }
    private void UpdateProgressBar()
    {
        progressBar.value = currentProgress;
    }
}
