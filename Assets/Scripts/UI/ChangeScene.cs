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
        switch (scene)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
            case 2:
                SceneManager.LoadScene("test1");
                break;
            case 3:
                SceneManager.LoadScene("test2");
                break;
            case 4:
                SceneManager.LoadScene("test3");
                break;
            default:
                break;
        }
    }
}
