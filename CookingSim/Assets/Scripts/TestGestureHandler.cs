using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GestureRecognizer;
using System.Linq;

public class TestGestureHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRecognize(RecognitionResult result)
    {
        if(result != RecognitionResult.Empty)
        {
            Debug.Log("Recognized");
        }
        else
        {
            Debug.Log("Not Recognized");
        }
    }
}
