using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int level = 1;

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject gameUI;
    public GameObject endUI;
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameUI.SetActive(false);
            GameUIHandler.Instance.SetScore();
            endUI.SetActive(true);
            
            GameObject.Find("SpawnManager").SetActive(false);
        }
    }   

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
