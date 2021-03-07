using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Button instructionsButtonBack;

    public void Awake()
    {
        instructionsButtonBack.onClick.AddListener(OnClickInstructionsBack);
    }

    void OnClickInstructionsBack()
    {
        LAGameManager.Instance.BackToMainMenu();
        LAGameManager.Instance.dirkams.gameObject.SetActive(true);
    }

}
