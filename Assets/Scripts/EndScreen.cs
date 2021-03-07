using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text dirkams;
    public Text player;
    public Text temps;

    private void OnEnable()
    {
        dirkams.text = "Dirkams: " + LAGameManager.nDirkams.ToString();
        player.text = LAGameManager.playerName;
        temps.text = "Temps: " + ((int)Time.time / 60).ToString() + "minuts i " + ((int)Time.time % 60).ToString() + " segons.";
    }

}
