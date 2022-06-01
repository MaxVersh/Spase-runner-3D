using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    public static GameUIHandler Instance; 
    public Text scoreText;
    public Text bestScoreText;
    public int score;
    public int bestScore;
    public Text scoreTextEnd;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        loadScore();
        score = 0;
        scoreText.text = "0";
        player = GameObject.FindWithTag("Player");
    }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)player.transform.position.z;
        scoreText.text = score.ToString();
    }

    class SaveData
    {
        public int bestScore;
        public string name;
    }
    
    void loadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            bestScoreText.text = "Best score: " + data.bestScore.ToString();
        }
    }

    void saveScore()
    {
        
        SaveData data = new SaveData();

        if (score > bestScore)
        {
            data.bestScore = score;
        }
        else
        {
            data.bestScore = bestScore;
        }
        

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void ExitGame()
    {
        saveScore();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    public void ToMenu()
    {
        saveScore();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        saveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetScore()
    {
        scoreTextEnd.text = score.ToString();
    }
}
