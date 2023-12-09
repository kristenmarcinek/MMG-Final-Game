using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private int sceneTracker = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        sceneTracker++;
        
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Story")
        {
            inkJSON = Resources.Load<TextAsset>("scene" + sceneTracker);
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("interact pressed");
            
        }
    }
}
