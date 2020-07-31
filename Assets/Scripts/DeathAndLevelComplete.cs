using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAndLevelComplete : MonoBehaviour
{
    public static bool LvlIsComplete = false;

    public GameObject lvlCompleteUI;
    public GameObject gameOverUI;

    public Animator transitionAnim;

    // Update is called once per frame
    void Update()
    {
        if (ExitScript.playerHasExited == true)
        {
            LvlComplete();
            ExitScript.playerHasExited = false;
        }

        if(PlayerHealth.playerHasDied == true)
        {
            GameOver();
            PlayerHealth.playerHasDied = false;
        }
    }

    public void LvlComplete()
    {
        lvlCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        //gameOverUI.SetActive(true);
        //Time.timeScale = 0f;
        StartCoroutine(DeathOver());
    }

    public void LoadMenu()
    {
        lvlCompleteUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(LoadScene());
    }

    public void NextLevel()
    {
        lvlCompleteUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(LoadSceneOne());
    }

    IEnumerator LoadSceneOne()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }

    IEnumerator DeathOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
