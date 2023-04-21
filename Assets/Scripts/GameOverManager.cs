using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverScreen;
    private void OnEnable()
    {
        PlayerController.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        gameOverScreen.SetActive(true);
        // Restart the game after a delay
        //StartCoroutine(RestartGame(0f));
    }

    private IEnumerator RestartGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // This function may  be redundant
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
