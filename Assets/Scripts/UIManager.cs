using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public PlayerSwitcher player1, player2;

    public Text player1Yellow;
    public Text player1Pink;
    public Text player1Green;

    public Text player2Yellow;
    public Text player2Pink;
    public Text player2Green;

    public GameObject panelGameInfo;
    public Button resetButton;

    public string startText = "Select player!";
    public string gameOverText = "Game over! Press reset button to continue";

    void Awake()
    {
        if (instance)
        {
            Debug.LogError("MORE THAN 1 UIMANAGER, ABORTING " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void ShowPanel(bool isVisible)
    {
        panelGameInfo.SetActive(isVisible);
    }

    private void SetTextOnPanel(string newText)
    {
        if (!panelGameInfo.activeSelf) ShowPanel(true);
        panelGameInfo.GetComponentInChildren<Text>().text = newText;
    }

    private void ShowResetButton(bool isVisible)
    {
        resetButton.gameObject.SetActive(isVisible);
    }

    public void OnGameOverEvent()
    {
        SetTextOnPanel(gameOverText);
        ShowResetButton(true);
    }

    public void Reset()
    {
        SetTextOnPanel(startText);
        ShowResetButton(false);

        player1.playerScore[StuffController.SType.Yellow] = 0;
        player1.playerScore[StuffController.SType.Pink] = 0;
        player1.playerScore[StuffController.SType.Green] = 0;

        player2.playerScore[StuffController.SType.Yellow] = 0;
        player2.playerScore[StuffController.SType.Pink] = 0;
        player2.playerScore[StuffController.SType.Green] = 0;
        Refresh();

        player1.ResetPosition();
        player2.ResetPosition();
    }

    public void Refresh()
    {
        player1Yellow.text = player1.playerScore[StuffController.SType.Yellow].ToString();
        player1Pink.text = player1.playerScore[StuffController.SType.Pink].ToString();
        player1Green.text = player1.playerScore[StuffController.SType.Green].ToString();

        player2Yellow.text = player2.playerScore[StuffController.SType.Yellow].ToString();
        player2Pink.text = player2.playerScore[StuffController.SType.Pink].ToString();
        player2Green.text = player2.playerScore[StuffController.SType.Green].ToString();
    }
}
