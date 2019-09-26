using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] public GameObject[] Pool;
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
}
