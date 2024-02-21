using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatsUI : MonoBehaviour
{
    public Text gameTimeUI;
    public Text randomRewardUI;
    public Text stableRewardUI;

    public GameObject winText;
    public GameObject diedText;

    public void AssignStatsToUI(bool isWin)
    {
        //Timer
        float time = GameManager.Instance.GetGameTime();
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        gameTimeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Random Reward
        string randomBox = "";
        foreach (int round in GameManager.Instance.randomWave)
        {
            int _round = round + 1;
            if (GameManager.Instance.randomWave.IndexOf(round) >0)
                randomBox = randomBox + "," + _round;
            else
                randomBox = randomBox + _round;
        }
        randomRewardUI.text = randomBox;

        //Stable Reward
        string stableBox = "";
        foreach (int round in GameManager.Instance.stableWave)
        {
            int _round = round + 1;
            if (GameManager.Instance.randomWave.IndexOf(round) > 0)
                stableBox = stableBox + "," + _round;
            else
                stableBox = stableBox + _round;
        }

        stableRewardUI.text = stableBox;

        if (isWin)
        {
            winText.SetActive(true);
            diedText.SetActive(false);
        }
        else
        {
            diedText.SetActive(true);
            winText.SetActive(false);
        }
    }
}
