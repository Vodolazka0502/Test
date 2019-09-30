using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad 
{
   public static void SavePlayerData(PlayerSwitcher player,int playerNum)
    {
        // save to file (in progress)
        string data = JsonUtility.ToJson(player);
        SaveDataToFile(data, @"Data\Player" + playerNum + ".txt");
    }

    public static void SavePoolData()
    {
        // save to file
        string[] data1 = new string[PoolManager.instance.Pool.Length];

        for (int i = 0; i< PoolManager.instance.Pool.Length;i++)
        {
            data1[i] = PoolManager.instance.Pool[i].activeSelf.ToString();
        }

        string data = JsonUtility.ToJson(data1);
        File.WriteAllLines(@"Data\PoolInfo.txt", data1);
    }

    public static void SaveGame()
    {
        //(in progress)
        SavePoolData();
        //SavePlayerData(PlayerSwitcher player, int playernum);
    }

    public static bool[] LoadPoolData()
    {
        // load from file 
        string path = @"Data\PoolInfo.txt";

        if (!File.Exists(path)) return null;

        string[] loadString = File.ReadAllLines(path);
        bool[] data = new bool[loadString.Length];
         for(int i = 0; i < loadString.Length; i++)
         {
             data[i] = loadString[i] == "True";
         }
         
        return data;
    }

    public static PlayerSwitcher LoadPlayerData(int playerNum)
    {
        // load from file (in progress)
        string data = ReedDataFromFile(@"Data\Player" + playerNum + ".txt");
        PlayerSwitcher loaded = JsonUtility.FromJson<PlayerSwitcher>(data);        

        return loaded;
    }
    private static void SaveDataToFile(string data, string path)
    {
        //string path = @"Data\MyTest.txt";   (in progress)
        if (!File.Exists(path))
        {
            // Create a file to write.
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

