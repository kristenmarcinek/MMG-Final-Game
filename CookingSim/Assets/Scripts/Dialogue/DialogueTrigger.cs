using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private void Awake()
    {
        
    }
    private void Start()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("interact pressed");
            
        }
    }
}
