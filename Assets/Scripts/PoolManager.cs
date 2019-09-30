using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolManager : MonoBehaviour
{

    public GameObject[] Pool;
    public static PoolManager instance;

    public UnityEvent GameOverEvent;

    private int takenCount= 0;


    void Awake()
    {
        if(instance)
        {
            Debug.LogError("MORE THAN 1 POOLMANAGER, ABORTING " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Reset()
    {
        foreach (GameObject element in Pool)
        {
            element.SetActive(true);
        }
        takenCount = 0;
        //Load(); // load game if data file exist
    }
    private bool IsPoolHasObj(GameObject obj)
    {
        foreach (GameObject element in Pool)
        {
            if (element == obj) return true;
        }
        return false;
    }

    public bool Deactivate(GameObject obj)
    {

        if (IsPoolHasObj(obj))
        {
            obj.SetActive(false);
            //SaveLoad.SavePoolData();
            takenCount++;
            if (IsMinigameCompleted()) GameOverEvent.Invoke();
            
            return true;
        }

        return false;
    }

    private void Load()
    {
        bool[] data = SaveLoad.LoadPoolData();

        if (data == null) return;
        for(int i = 0; i<data.Length; i++)
        {
             if (!data[i]) instance.Pool[i].SetActive(false);
        }
        if (IsMinigameCompleted()) GameOverEvent.Invoke();
    }

    private bool IsMinigameCompleted()
    {
        return takenCount == instance.Pool.Length;
    }
}
