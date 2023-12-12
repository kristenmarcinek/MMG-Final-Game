using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    
    private Story currentStory;

    public bool dialogueIsPlaying;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public GameObject continueButton;
<<<<<<< Updated upstream
    
=======


>>>>>>> Stashed changes
    private void Awake()
    {
        if (instance !=null)
        {
            Debug.LogWarning("There is more than one instance of DialogueManager");
        }
        instance = this;

<<<<<<< Updated upstream
         //dialogueIsPlaying = true;
        //dialoguePanel.SetActive(true);
=======
>>>>>>> Stashed changes
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index]= choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        currentStory = new Story(inkJSON.text);
        
<<<<<<< Updated upstream
=======
        currentStory.BindExternalFunction("playScene",(string sceneName) =>
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Scene name: " + sceneName);
        }); 
>>>>>>> Stashed changes
        ContinueStory();
      

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        // else
        // {
        //     //ExitDialogueMode();
        //     Debug.Log("No more text");
        // }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        currentStory.UnbindExternalFunction("playScene");
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            continueButton.SetActive(true);
            if (currentStory.currentChoices.Count > 0)
            {
                DisplayChoices();
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        Debug.Log("Displaying choices");
        List<Choice> currentChoices = currentStory.currentChoices;
        Debug.Log("Number of choices: " + currentChoices.Count);


        if (currentChoices.Count > choices.Length)
        {
            Debug.LogWarning("There are more choices than UI elements");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            continueButton.SetActive(false);
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }


        LayoutRebuilder.ForceRebuildLayoutImmediate(dialoguePanel.GetComponent<RectTransform>());

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        Debug.Log("Selecting first choice");
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        Debug.Log("Making choice: " + choiceIndex);
        currentStory.ChooseChoiceIndex(choiceIndex);
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        ContinueStory();
        
    }
}


