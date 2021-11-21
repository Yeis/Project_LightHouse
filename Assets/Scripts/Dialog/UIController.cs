using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public void DisplayDialog(DialogScriptableObject dialog) {
        textDisplay.fontSize = dialog.fontSize;
        textDisplay.font = dialog.fontAsset;
        StartCoroutine(Type(dialog));
        //Clear up after text

    }

    IEnumerator Type(DialogScriptableObject dialog)
    {
        for (int i = 0; i < dialog.sentences.Count; i++)
        {
            foreach (char letter in dialog.sentences[i].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(dialog.textSpeed);
            }
            yield return new WaitForSeconds(dialog.timeBetweenLines);
            textDisplay.text = "";
        }
        textDisplay.text = "";
        dialog.hasEnded = true;
    }
}
