using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LAGameManager : MonoBehaviour
{
    private static LAGameManager instance;

    public static LAGameManager Instance {
        get
        {
           return instance;
        }
    }

    public Text dirkams;
    private static int nDirkams = 0;

    public Instructions instructions;
    public Button instructionsButton;

    public InitialScreen initialScreen;
    
    public Levels levels;
    public LevelSelectorScreen levelIconsScreen;

    //public List<LevelSelectorIcon> levelsList = new List<LevelSelectorIcon>();
    private Dictionary<int, Level> levelsDict;
    private Dictionary<int, LevelSelectorIcon> iconsDict;
    private Dictionary<Level, LevelSelectorIcon> levelsIconsDict;
    private Dictionary<LevelSelectorIcon, Level> iconsLevelsDict;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        instructionsButton.onClick.AddListener(OnClickInstructions);

        levelsDict = new Dictionary<int, Level>();
        iconsDict = new Dictionary<int, LevelSelectorIcon>();
        levelsIconsDict = new Dictionary<Level, LevelSelectorIcon>();
        iconsLevelsDict = new Dictionary<LevelSelectorIcon, Level>();

        initialScreen.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);
        levelIconsScreen.gameObject.SetActive(false);
        levels.gameObject.SetActive(false);

        foreach (Level lv in levels.levels)
        {
            lv.gameObject.SetActive(false);
            levelsDict.Add(lv.ID, lv);
        }

        foreach (LevelSelectorIcon icon in levelIconsScreen.levelIcons)
        {
            iconsDict.Add(icon.levelID, icon);
        }

        foreach (Level level in levels.levels)
        {
            levelsIconsDict.Add(level, iconsDict[level.ID]);
        }

        foreach (LevelSelectorIcon lvIcon in levelIconsScreen.levelIcons)
        {
            Level level = levelsDict[lvIcon.levelID];
            iconsLevelsDict.Add(lvIcon, level);
            if (level.locked)
                lvIcon.SetButtonSprite(levelIconsScreen.levelLocked);
            else if (level.completed)
                lvIcon.SetButtonSprite(levelIconsScreen.levelCompleted);
            else
                lvIcon.SetButtonSprite(levelIconsScreen.levelUnlocked);
        }
    }

    public void OnClickInstructions()
    {
        instructions.gameObject.SetActive(true);
        initialScreen.gameObject.SetActive(false);
        levels.gameObject.SetActive(false);
        levelIconsScreen.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        instructions.gameObject.SetActive(false);
        levels.gameObject.SetActive(false);
        levelIconsScreen.gameObject.SetActive(false);
        initialScreen.gameObject.SetActive(true);
    }

    public void BackToLevelSelection()
    {
        foreach (Level lv in levels.levels)
        {
            lv.gameObject.SetActive(false);
        }
        initialScreen.gameObject.SetActive(false);
        levels.gameObject.SetActive(false);
        levelIconsScreen.gameObject.SetActive(true);
    }

    public void RequestSelectLevel(LevelSelectorIcon levelicon)
    {
        Level level = iconsLevelsDict[levelicon];

        if (level.locked)
            return;

        foreach (Level lv in levels.levels)
        {
            lv.gameObject.SetActive(false);
        }
        levelIconsScreen.gameObject.SetActive(false);
        levels.gameObject.SetActive(true);
        level.gameObject.SetActive(true);
    }

    public void RequestCompleteLevel(Level level)
    {
        if (level.completed)
            return;

        switch (level.ID)
        {
            case 1:
                if (level.answer.text.Equals("Ludd idn Muhammad idn Lubb ibn Musa al-Qasawi idn Musa idn Furtun idn Qasi idn Furtun"))
                {
                    CompleteLevel(level);
                    level.answerFeedback.text = "Resposta correcta !!!";
                }
                else
                    level.answerFeedback.text = "Resposta incorrecta, torna-ho a provar :(";
                break;
            case 2:
                
                if (level.answer.text.Split(',').Length != 3)
                {
                    level.answerFeedback.text = "Epp! Us heu descuidat d'escriure totes les respostes.";
                    return;
                }
                else if (level.answer.text.Equals("Ishtar,Lleida,Segre"))
                {
                    CompleteLevel(level);
                    level.answerFeedback.text = "Resposta correcta !!!";
                }
                else
                    level.answerFeedback.text = "Resposta incorrecta, torna-ho a provar :(";
                break;
            default:
                break;
        }
    }

    private void CompleteLevel(Level level)
    {
        level.completed = true;
        nDirkams += level.dirkams;
        dirkams.text = nDirkams.ToString();
        level.completeButton.interactable = false;
        foreach(Level lv in level.UnlockableLevels)
        {
            RequestUnlockLevel(lv);
        }
        LevelSelectorIcon icon = levelsIconsDict[level];
        icon.SetButtonSprite(levelIconsScreen.levelCompleted);

        BackToLevelSelection();
    }

    public void RequestUnlockLevel(Level level)
    {
        if (!level.locked || !levelsIconsDict.ContainsKey(level))
            return;

        LevelSelectorIcon icon = levelsIconsDict[level];
        icon.SetButtonSprite(levelIconsScreen.levelUnlocked);

        level.locked = false;
        
    }

    private LevelSelectorIcon GetIconFromLevel(Level level)
    {
        if (!levelsIconsDict.ContainsKey(level))
            return null;

        return levelsIconsDict[level];
    }

    private Level GetLevelFromIcon(LevelSelectorIcon icon)
    {
        if (!iconsLevelsDict.ContainsKey(icon))
            return null;

        return iconsLevelsDict[icon];
    }
}
