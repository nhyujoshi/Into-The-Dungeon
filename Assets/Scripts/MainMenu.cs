using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
       
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
