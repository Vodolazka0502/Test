using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    private Animator thisAnim;
    public PlayerConroller playerController;
    public Dictionary<StuffController.SType, int> playerScore = new Dictionary<StuffController.SType, int>();
    public int playerNum;
    private Vector2 StartPosition { get; set; }

    void Awake()
    {
        playerScore.Add(StuffController.SType.Green,0);
        playerScore.Add(StuffController.SType.Pink,0);
        playerScore.Add(StuffController.SType.Yellow,0);
        thisAnim = GetComponent<Animator>();
        StartPosition = transform.position;
    }


    void OnMouseDown()
    {
        if (GameController.instance.gameState == GameController.GameState.Play)
        {
            playerController.SwitchObject(GetComponent<Transform>());
            PlaySelectedAnim();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if( PoolManager.instance.Deactivate(other.gameObject))
        {
            playerScore[other.GetComponent<StuffController>().thisType]++;
            //SaveLoad.SavePlayerData(this, playerNum);
            UIManager.instance.Refresh();
        }
    }
    public void PlaySelectedAnim()
    {
        thisAnim.CrossFade("SelectPlayer", 0.1f);
    }

    public void ResetPosition()
    {
        transform.position = StartPosition;
    }
}
