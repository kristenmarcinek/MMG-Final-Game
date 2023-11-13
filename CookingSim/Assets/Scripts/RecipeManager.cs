using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeManager : MonoBehaviour
{
    public List<float> scoresList;
    public static RecipeManager sharedInstance;


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
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
}