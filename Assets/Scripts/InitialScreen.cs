using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialScreen : MonoBehaviour
{
    public Button initialScreenToLevelSelection;
    public Button initialScreenInstructions;

    public InputField playerName;
    public Text feedBackText;

    private void Awake()
    {
        initialScreenToLevelSelection.onClick.AddListener(OnClickInitialScreenToLevelSelection);
        initialScreenInstructions.onClick.AddListener(OnClickInitialScreenInstructions);
    }

    void OnClickInitialScreenToLevelSelection()
    {
        if (!string.IsNullOrEmpty(playerName.text))
        {
            LAGameManager.Instance.RequestChangePlayerName(playerName.text);
            LAGameManager.Instance.BackToLevelSelection();
            LAGameManager.Instance.dirkams.gameObject.SetActive(true);
        }
        else
            feedBackText.text = "Escriu el teu nom abans de començar.";
    }

    void OnClickInitialScreenInstructions()
    {
        LAGameManager.Instance.OnClickInstructions();
    }
}
