using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/DialogueSO")]
public class DialogueSO : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogueText;
}
