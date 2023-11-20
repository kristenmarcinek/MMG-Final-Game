using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeManager : MonoBehaviour
{
    public List<float> scoresList;
    public static RecipeManager sharedInstance;
    public GameObject targetObject;
    public GameObject[] recipeSteps;
    public int stepTracker = 0;
    


    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        recipeSteps = GameObject.FindGameObjectsWithTag("step");
        
        
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
       foreach (GameObject step in recipeSteps)
        {
            targetObject = step;
            DeactivateAllChildren();

          
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextStep();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (float score in scoresList)
            {
                Debug.Log("the scores list contains:" + score.ToString());

            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (float score in scoresList)
            {
                RecipeScore();

            }

        }

        // Check for user input or any other condition to activate the objects
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activate the objects
            ActivateAllChildren();
        }

        // Check for user input or any other condition to deactivate the objects
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Deactivate the objects
            DeactivateAllChildren();
        }


    }



    public void RecipeScore()
    {
        //foreach (float score in scoresList)
        //{
        //    float Sum = 0;
        //    Sum += score;
        //    float average = Sum / scoresList.Count;
        //    Debug.Log("the average is:" + average.ToString());
        //}

        float total = scoresList.Sum();
        float average = total / scoresList.Count;
        Debug.Log("the average is:" + average.ToString());

    }

    void ActivateAllChildren()
    {
        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Activate all children of the targetObject
            foreach (Transform child in targetObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Target object not assigned");
        }
    }

    void DeactivateAllChildren()
    {
        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Deactivate all children of the targetObject
            foreach (Transform child in targetObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Target object not assigned");
        }
    }

    void ActivateNextChild()
    {
        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Check if the stepTracker is within the range of the children count
            if (stepTracker < targetObject.transform.childCount)
            {
                // Activate the next child
                targetObject.transform.GetChild(stepTracker).gameObject.SetActive(true);
                // Increment the stepTracker
                stepTracker++;
            }
            else
            {
                Debug.Log("No more children to activate");
            }
        }
        else
        {
            Debug.LogError("Target object not assigned");
        }
    }   

    void NextStep()
    {
        DeactivateAllChildren();
        stepTracker++;
        targetObject = GameObject.Find("Step " + stepTracker.ToString());
        ActivateAllChildren();
    }
}