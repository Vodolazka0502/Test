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

    public void RefreshUI()
    {
        player1Yellow.text = player1.playerScore[StuffController.SType.Yellow].ToString();
        player1Pink.text = player1.playerScore[StuffController.SType.Pink].ToString();
        player1Green.text = player1.playerScore[StuffController.SType.Green].ToString();

        player2Yellow.text = player2.playerScore[StuffController.SType.Yellow].ToString();
        player2Pink.text = player2.playerScore[StuffController.SType.Pink].ToString();
        player2Green.text = player2.playerScore[StuffController.SType.Green].ToString();
    }
}
