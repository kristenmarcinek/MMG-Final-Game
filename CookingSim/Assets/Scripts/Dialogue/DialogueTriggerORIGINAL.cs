// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class DialogueTrigger : MonoBehaviour
// {
//     [Header("Ink JSON")]
//     [SerializeField] private TextAsset inkJSON;
//     [SerializeField] private int sceneTracker = 0;
//     private static bool isCreated = false;

//     private void Awake()
//     {
//         if (!isCreated)
//         {
//             DontDestroyOnLoad(this.gameObject);
//             isCreated = true;
//             SceneManager.sceneLoaded += OnSceneLoaded;
//         }
//         else
//         {
//             // If an instance already exists, destroy the duplicate
//             Destroy(this.gameObject);
//             return;
//         }
//     }
//     private void Start()
//     {
        
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
            
//             Debug.Log("interact pressed");
            
//         }
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         // This method will be called whenever a new scene is loaded
//         Debug.Log("Scene loaded: " + scene.name);
        
//         if (SceneManager.GetActiveScene().name == "Story")
//         {
//             Debug.Log("scene" + sceneTracker);
//             sceneTracker++;
//             inkJSON = Resources.Load<TextAsset>("scene" + sceneTracker);
//             DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
//         }
//     }
// }
