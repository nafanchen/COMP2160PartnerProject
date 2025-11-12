using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Dictionary<int, float> lastTimes = new Dictionary<int, float>();
    private Dictionary<int, float> bestTimes = new Dictionary<int, float>();

    private void Awake()
    {
        LoadAllTimes();
    }

    public void UpdateLastTime(int level, float lastTime)
    {
        lastTimes[level] = lastTime;
        PlayerPrefs.SetFloat("Level" + level + "_LastTime", lastTime);

        if (!bestTimes.ContainsKey(level) || (lastTime > 0 && (bestTimes[level] == 0 || lastTime < bestTimes[level])))
        {
            bestTimes[level] = lastTime;
            PlayerPrefs.SetFloat("Level" + level + "_BestTime", lastTime);
        }
        PlayerPrefs.Save();
    }

    public string GetLastTime(int level)
    {
        if (lastTimes.TryGetValue(level, out float time) || LoadTime(level, isBestTime: false))
        {
            return time > 0 ? FormatTime(lastTimes[level]) : "incomplete";
        }
        return "incomplete";
    }

    public string GetBestTime(int level)
    {
        if (bestTimes.TryGetValue(level, out float time) || LoadTime(level, isBestTime: true))
        {
            return time > 0 ? FormatTime(bestTimes[level]) : "incomplete";
        }
        return "incomplete";
    }

    private bool LoadTime(int level, bool isBestTime)
    {
        string key = "Level" + level + (isBestTime ? "_BestTime" : "_LastTime");
        if (PlayerPrefs.HasKey(key))
        {
            float time = PlayerPrefs.GetFloat(key);
            if (isBestTime)
            {
                bestTimes[level] = time;
            }
            else
            {
                lastTimes[level] = time;
            }
            return true;
        }
        return false;
    }

    private void LoadAllTimes()
    {
        for (int i = 1; i <= 3; i++)
        {
            LoadTime(i, isBestTime: false);
            LoadTime(i, isBestTime: true);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int hundredths = Mathf.FloorToInt((time * 100) % 100);
        return $"{minutes:00}:{seconds:00}.{hundredths:00}";
    }
}
