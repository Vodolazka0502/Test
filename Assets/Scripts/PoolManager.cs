using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] Pool;
    public static PoolManager instance;

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
    void Start()
    {
        Load(); // load game if data file exist
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
            SaveLoad.SavePoolData();
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
    }
}
