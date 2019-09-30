using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public enum GameState { Play, GameOver };
    public GameState gameState = GameState.Play;

    void Awake()
    {
        if (instance)
        {
            Debug.LogError("MORE THAN 1 GameController, ABORTING " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        instance = this;
       // StartNewGame();
    }

    public void OnGameOverEvent()
    {
        ChangeGameState(GameState.GameOver);
    }

    public void StartNewGame()
    {
        ChangeGameState(GameState.Play);
        
    }


    private void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Play:
                UIManager.instance.Reset();
                PoolManager.instance.Reset();
                break;
            case GameState.GameOver:
                UIManager.instance.OnGameOverEvent();
                break;
        }
        gameState = newState;
    }


}
