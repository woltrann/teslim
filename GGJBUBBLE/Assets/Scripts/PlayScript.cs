using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayScript : MonoBehaviour
{
    void Update()
    {
        // Enter tu�una bas�l�p bas�lmad���n� kontrol et
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayGame();
        }

        // X tu�una bas�l�p bas�lmad���n� kontrol et
        if (Input.GetKeyDown(KeyCode.X))
        {
            quitgame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void quitgame()
    {
        Application.Quit();

    }
}
