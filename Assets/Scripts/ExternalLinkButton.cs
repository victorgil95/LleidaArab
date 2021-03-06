using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExternalLinkButton : MonoBehaviour
{
    Button button;
    public string url;

    private void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
        if (button)
        {
            button.onClick.AddListener(OnClickButton);
        }
    }

    private void OnClickButton()
    {
        Application.OpenURL(url);
    }


}
