﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad 
{
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";


   public static void SavePlayerData(PlayerSwitcher player,int playerNum)
    {
        string data = JsonUtility.ToJson(player);
        SaveDataToFile(data, @"Data\Player" + playerNum + ".txt");
        // save to file
    }

    public static void SavePoolData()
    {// save to file
        string[] data1 = new string[PoolManager.instance.Pool.Length];
        for (int i = 0; i< PoolManager.instance.Pool.Length;i++)
        {
            data1[i] = PoolManager.instance.Pool[i].activeSelf.ToString();
        }


        string data = JsonUtility.ToJson(PoolManager.instance.Pool);
        // SaveDataToFile(data, @"Data\PoolInfo.txt");
        // SaveDataToFile(data, @"Data\PoolInfo.txt");
        
       // string saveString = string.Join(SAVE_SEPARATOR, data1);
        File.WriteAllText(@"Data\PoolInfo.txt", JsonUtility.ToJson(PoolManager.instance.Pool));

    }

    public static void SaveGame()
    {
        SavePoolData();
        //SavePlayerData(PlayerSwitcher player, int playernum);
    }

    public static PoolManager LoadPoolData()
    {
        // load from file 
        string data = ReedDataFromFile(@"Data\PoolInfo.txt");
        PoolManager loaded = JsonUtility.FromJson<PoolManager>(data);

        return loaded;
    }

    public static PlayerSwitcher LoadPlayerData(int playerNum)
    {
        // load from file 
        string data = ReedDataFromFile(@"Data\Player" + playerNum + ".txt");
        PlayerSwitcher loaded = JsonUtility.FromJson<PlayerSwitcher>(data);        

        return loaded;
    }
    private static void SaveDataToFile(string data, string path)
    {
        //string path = @"Data\MyTest.txt";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(data);

            }
        }
    }

    private static string ReedDataFromFile(string path)
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string s;

            return s = sr.ReadLine();
        } 
    }
}

