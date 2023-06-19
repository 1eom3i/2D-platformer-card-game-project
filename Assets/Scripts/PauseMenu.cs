using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	[SerializeField] GameObject comboList;
	[SerializeField] GameObject pauseButton;
    public static bool IsPaused = false;

    void Update(){
        if (IsPaused){
            pauseMenu.SetActive(true);
            IsPaused = true;
        } else{
            pauseMenu.SetActive(false);
			//comboList.SetActive(false);
            IsPaused = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (IsPaused){
                Resume();				
            } else {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
	
	public void Back(){
		//pauseMenu.SetActive(true);
		comboList.SetActive(false);
		//pauseButton.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = true;
	}

 	public void ViewCombo()
    {
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
		//pauseButton.SetActive(false);
		comboList.SetActive(true);
    }

    public void Restart(int i)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(i);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(0);
    }
    
}

