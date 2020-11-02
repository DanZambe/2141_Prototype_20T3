using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    public Canvas pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseButtonClick()
	{
        Time.timeScale = 0;
        pauseMenu.enabled = true;
	}


    public void ResumeButton()
	{
        Time.timeScale = 1;
        pauseMenu.enabled = false;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
