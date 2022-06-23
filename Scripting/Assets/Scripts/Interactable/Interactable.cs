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
    private ArrowPointy arrowPointy;
    // Start is called before the first frame update
    void Start()
    {
        interactPrompt = transform.GetChild(2).gameObject;
        theSpookySkeleton = GameObject.FindGameObjectWithTag("Player").gameObject;
        arrowPointy = FindObjectOfType<ArrowPointy>();
        if (transform.parent.tag != "Enemy")
        {
            arrowPointy.target.Add(this.gameObject);
        }
        currentProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Calls from triggerbox to check if player has collided.
        if (playerCollided == true)
        {
            check = false;
            progressBar.maxValue = maxProgess;
            //Disables functionality if the interactable item is an Enemy and the player is currently disguised.
            if (transform.parent.tag == "Enemy" && theSpookySkeleton.GetComponent<SkeletonController>().disguised == true)
            {

            }
            else
            {
                //Increase interact bar value when player presses E.
                interactPrompt.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    theSpookySkeleton.GetComponent<SkeletonController>().interacting = true;
                    interacting = true;
                    currentProgress += Time.deltaTime;
                }
                else
                {
                    theSpookySkeleton.GetComponent<SkeletonController>().interacting = false;
                    interacting = false;
                }
            }
            UpdateProgressBar();

        }
        //Changes all values back when player exits triggerbox.
        else if (playerCollided == false)
        {
            if (check == false)
            {
                theSpookySkeleton.GetComponent<SkeletonController>().interacting = false;
                interacting = false;
                interactPrompt.SetActive(false);
                UpdateProgressBar();
                check = true;
            }

        }
        //Constaintly decreases progress bar value when it is not increasing.
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
            //Destroy object and disguise player when progress bar reaches max progress and the object is an enemy.
            if (transform.parent.tag == "Enemy")
            {
                interactPrompt.SetActive(false);
                interacting = false;
                theSpookySkeleton.GetComponent<SkeletonController>().interacting = false;
                theSpookySkeleton.GetComponent<SkeletonController>().EnableDisguise();
                Destroy(transform.parent.gameObject);
            }
            //Destroys objecy when progress bar reaches max progress.
            else
            {
                interactPrompt.SetActive(false);
                interacting = false;
                theSpookySkeleton.GetComponent<SkeletonController>().interacting = false;
                arrowPointy.target.Remove(this.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }
        //Sets progress bar to active if value is above 0.
        if (currentProgress > 0)
        {
            progressBar.gameObject.SetActive(true);
        }
    }
    //Update visable progress bar.
    private void UpdateProgressBar()
    {
        progressBar.value = currentProgress;
    }
}
