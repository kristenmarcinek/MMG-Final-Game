// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Ink.Runtime;
// using UnityEngine.SceneManagement;

// public class InkExternalFunctions : MonoBehaviour
// {
//     // public TextAsset scene5;
//     // Story scene5Story;

//     // private void Awake()
//     // {
//     //     scene5Story = new Story(scene5.text);
//     // }

//     public void Start()
//     {
//         //Bind();
//     }

//     public void Bind()
//     {
//         scene5Story.BindExternalFunction("sandwichScene", () =>
//         {
//             SceneManager.LoadScene("Sandwich");
//         });

//         scene5Story.BindExternalFunction("saladScene", () =>
//         {
//             SceneManager.LoadScene("Salad");
//         });
//     }
// }
