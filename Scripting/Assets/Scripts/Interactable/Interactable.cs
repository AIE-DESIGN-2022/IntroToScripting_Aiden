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
    private bool check;
    // Start is called before the first frame update
    void Start()
    {
        interactPrompt = transform.GetChild(2).gameObject;
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player").gameObject;
        currentProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollided == true)
        {
            check = false;
            progressBar.maxValue = maxProgess;
            if (transform.parent.tag == "Enemy" && theSpookySkeleton.GetComponent<Skeleton>().disguised == true)
            {
                //interactPrompt.SetActive(false);
            }
            else
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
            }
            UpdateProgressBar();

        }
        else if (playerCollided == false)
        {
            if (check == false)
            {
                theSpookySkeleton.GetComponent<Skeleton>().interacting = false;
                interacting = false;
                interactPrompt.SetActive(false);
                UpdateProgressBar();
                check = true;
            }

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
            if (transform.parent.tag == "Enemy")
            {
                interactPrompt.SetActive(false);
                interacting = false;
                theSpookySkeleton.GetComponent<Skeleton>().interacting = false;
                theSpookySkeleton.GetComponent<Skeleton>().disguised = true;
                Destroy(transform.parent.gameObject);
            }
            else
            {
                interactPrompt.SetActive(false);
                interacting = false;
                theSpookySkeleton.GetComponent<Skeleton>().interacting = false;
                Destroy(transform.parent.gameObject);
            }
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
