using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked() {
        launchscene(staticField.scenenbr);
    }
    public void launchscene(int scene) {
        Time.timeScale = 1f;
        switch (scene)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                staticField.actualLvl = 1;
                break;
            case 2:
                SceneManager.LoadScene("test1");
                staticField.actualLvl = 2;
                break;
            case 3:
                SceneManager.LoadScene("test2");
                staticField.actualLvl = 3;
                break;
            case 4:
                SceneManager.LoadScene("test3");
                staticField.actualLvl = 4;
                break;
            case 5:
                SceneManager.LoadScene("MainMenu");
                staticField.actualLvl = 0;
                break;
            case 6:
                SceneManager.LoadScene("MainMenu2");
                staticField.actualLvl = 0;
                break;
            default:
                break;
        }
    }
    public void btnEndLevel() {
        Debug.Log(staticField.actualLvl);
        Time.timeScale = 1f;

        switch (staticField.actualLvl)
        {
            case 1:
                SceneManager.LoadScene("test1");
                staticField.actualLvl++;
            break;
            case 2:
                SceneManager.LoadScene("test2");
                staticField.actualLvl++;
            break;
            case 3:
                SceneManager.LoadScene("test3");
                staticField.actualLvl++;
            break;
            case 4:
                SceneManager.LoadScene("MainMenu");
                staticField.actualLvl++;
            break;
        }
    }

    public void exitGame() {
        Application.Quit();
    }
}