using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public GameObject endCanvas;
    public GameObject NextLevelCanvas;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
        LoadNextLevel();
        }
    }

    public void LoadNextLevel () {
        int lvl = staticField.actualLvl;
        if (lvl >= 3) { // si on est au dernier niveau alors on affiche le canvas de fin de jeu
            endCanvas.SetActive (true);
        Time.timeScale = 0f;

            return;
        } else {
            NextLevelCanvas.SetActive(true);
        Time.timeScale = 0f;

        }
        System.IO.StreamReader file = new System.IO.StreamReader (Application.dataPath + "/Resources/save.txt"); //load text file with data
        string line;
        int saveLevel = 0;
        while ((line = file.ReadLine ()) != null) { //while text exists.. repeat           
            saveLevel = System.Convert.ToInt32 (line);
        }
        file.Close ();
        if (lvl == saveLevel) {
            using (StreamWriter writer = new StreamWriter (Application.dataPath + "/Resources/save.txt", false)) {
                writer.Write ((lvl + 1).ToString ());
            }
        }        
    }

    
}