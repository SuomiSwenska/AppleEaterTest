using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver instance;

    private void Awake()
    {
        instance = this;
    }

    public void SaveResult(int result)
    {
        bool isHaveResult = PlayerPrefs.GetInt("HaveResult") == -1;
        int prevResult = 0;

        if (isHaveResult)
        {
            string loadedjJsonData = System.IO.File.ReadAllText("data.json");
            ResultData loadedData = JsonUtility.FromJson<ResultData>(loadedjJsonData);
            prevResult = loadedData.bestResult;
        }


        if (result > prevResult)
        {
            ResultData myData = new ResultData();
            myData.bestResult = result;

            string jsonData = JsonUtility.ToJson(myData);
            System.IO.File.WriteAllText("data.json", jsonData);

            PlayerPrefs.SetInt("HaveResult", -1);
        }
    }

    public int GetBestResult()
    {
        bool isHaveResult = PlayerPrefs.GetInt("HaveResult") == -1;

        if (isHaveResult)
        {
            string loadedjJsonData = System.IO.File.ReadAllText("data.json");
            ResultData loadedData = JsonUtility.FromJson<ResultData>(loadedjJsonData);
            return loadedData.bestResult;
        }


        return 0;
    }
}
