using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private int scoresOnLevel = 0;
    public int globalScores = 0;

    private List<Color> keys;

    public enum Color { Black, Blue, Yellow, Green, Red, None };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadSettings();
            Initialized();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("scores", globalScores);
    }

    public void LoadSettings()
    {
        globalScores = PlayerPrefs.GetInt("scores");
    }

    public void LoadNewScene(string name, bool saveScores, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(name, sceneMode);
        if(saveScores) globalScores += scoresOnLevel;
        scoresOnLevel = 0;
    }

    public void IncScores(Text text)
    {
        scoresOnLevel++;
        text.text = scoresOnLevel.ToString();
    }

    public void AddKey(Color colorKey)
    {
        keys.Add(colorKey);
    }

    public bool HaveKey(Color colorDoor)
    {
        if (keys.Contains(colorDoor)) return true;
        return false;
    }

    private void OnApplicationQuit()
    {
        SaveSettings();
    }

    private void Initialized()
    {
        keys = new List<Color>();
    }
}
