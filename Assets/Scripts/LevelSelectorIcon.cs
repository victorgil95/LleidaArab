using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorIcon : MonoBehaviour
{
    public Button levelButton;
    public int levelID;

    public void Awake()
    {
        levelButton.onClick.AddListener(OnClickLevelIcon);
        
    }

    void OnClickLevelIcon()
    {
        LAGameManager.Instance.RequestSelectLevel(this);
    }

    public void SetButtonSprite(Sprite sprite)
    {
        levelButton.image.sprite = sprite;
    }
}
