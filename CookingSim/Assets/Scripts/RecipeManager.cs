using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using GestureRecognizer;

[System.Serializable]
public class StepData
{
    public string stepName;
    public List<GameObject> childObjectsList = new List<GameObject>();
    public GameObject recognizer;

}
public class RecipeManager : MonoBehaviour
{
    public static RecipeManager sharedInstance;

    public List<float> scoresList;
    public float currentScore;

    // A List to store all steps with their own list of child gameobjects
    public List<StepData> stepsList = new List<StepData>();


    private int m_currentStepIndex;
    private int m_currentChildIndex;

    private DrawDetector m_drawDetector;


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

        m_drawDetector = GameObject.Find("Canvas/DrawArea").GetComponent<DrawDetector>();
    }

    private void Start()
    {
        if (stepsList.Count > 0 && stepsList[0].childObjectsList.Count > 0)
        {

            m_currentStepIndex = 0;
            m_currentChildIndex = 0;
            Debug.Log(stepsList[m_currentStepIndex].childObjectsList[m_currentChildIndex]);

            InitializeSteps();
        }
        else
        {
            Debug.LogError("Invalid stepsList configuration. Make sure there is at least one step with at least one child object.");
        }


    }

    private void Update()
    {

        // Check if you are in the last index of child objects in the current step
        if (m_currentChildIndex < stepsList[m_currentStepIndex].childObjectsList.Count - 1)
        {
            if (currentScore > 50)
            {
                //reseting the score for the next step
                currentScore = 0;
                ActivateNextChild();
            }

        }
        else
        {
            // If yes, activate the next step
            ActivateNextStep();
        }




    }


    private void InitializeSteps()
    {
        foreach (var step in stepsList)
        {
            foreach (var childObject in step.childObjectsList)
            {
                step.recognizer.SetActive(false);
                childObject.SetActive(false);
            }
        }

        stepsList[m_currentStepIndex].recognizer.SetActive(true);
        stepsList[m_currentStepIndex].childObjectsList[m_currentChildIndex].SetActive(true);

    }

    public void RecipeScore()
    {

        float total = scoresList.Sum();
        float average = total / scoresList.Count;
        Debug.Log("the average is:" + average.ToString());

    }



    private void ActivateNextChild()
    {
        if (m_currentChildIndex < stepsList[m_currentStepIndex].childObjectsList.Count - 1)
        {
            stepsList[m_currentStepIndex].childObjectsList[m_currentChildIndex].SetActive(false);
            m_currentChildIndex++;
            stepsList[m_currentStepIndex].childObjectsList[m_currentChildIndex].SetActive(true);


        }
    }

    private void ActivateNextStep()
    {
        if (m_currentStepIndex < stepsList.Count - 1)
        {
            m_currentStepIndex++;
            m_currentChildIndex = 0;

            stepsList[m_currentStepIndex - 1].recognizer.SetActive(false);
            Destroy(stepsList[m_currentStepIndex - 1].recognizer);

            // Deactivate all children of the previous step
            foreach (var step in stepsList)
            {
                foreach (var childObject in step.childObjectsList)
                {

                    childObject.SetActive(false);
                }
            }

            stepsList[m_currentStepIndex].recognizer.SetActive(true);
            // Activate the first child of the current step
            stepsList[m_currentStepIndex].childObjectsList[m_currentChildIndex].SetActive(true);

            // Set the new recognizer for the DrawDetector script

            if (m_drawDetector != null)
            {
                Recognizer newRecognizer = stepsList[m_currentStepIndex].recognizer.GetComponent<Recognizer>();
                m_drawDetector.SetRecognizer(newRecognizer);
            }
        }
        else
        {
            Debug.LogWarning("No more steps to activate.");
        }

    }


    //private bool AreChildrenActive(int stepIndex)
    //{
    //    foreach (var childObject in stepsList[stepIndex].childObjectsList)
    //    {
    //        if (!childObject.activeSelf)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}



}
