using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueTextUI;
    [SerializeField] NewScriptableObjectScript dialogueSequence;
    [SerializeField] GameObject textPanel;
    [SerializeField] PlayerShooting PlayerShooting;

    int currentDialogueIndex = 0;
    bool waitForButtonPress = false;

    void Update()
    {
        if (waitForButtonPress && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((dialogueSequence.dialogueText.Length > 0) && collision.gameObject.CompareTag("Player"))
        {
            OpenTextBox();
            ShowNextDialogue();
        }
    }

    public void OpenTextBox()
    {
        textPanel.SetActive(true);
        Time.timeScale = 0f;
        PlayerShooting.DialoguePaused();
    }

    public void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogueSequence.dialogueText.Length)
        {
            dialogueTextUI.text = dialogueSequence.dialogueText[currentDialogueIndex];
            currentDialogueIndex++;
            waitForButtonPress = true;
        }
        else
        {
            CloseTextBox();
        }
    }

    public void CloseTextBox()
    {
        textPanel.SetActive(false);
        Time.timeScale = 1f;
        PlayerShooting.DialogueOnPause();
        Destroy(gameObject);
    }
}
