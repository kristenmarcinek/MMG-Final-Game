using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public RecipeManager recipeManager;
    public string sceneName;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        recipeManager = GameObject.Find("RecipeManagerObj").GetComponent<RecipeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(recipeManager.lastStepCompleted == true)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
