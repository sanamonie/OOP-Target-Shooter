using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HighScoreUiHandler : MonoBehaviour
{

    string HighScores;
    public Text highScoreText; 
    // Start is called before the first frame update
    void Start()
    {
       // PersistantData.Instance.getHighScores();
        string tempString = "";
        string[] names = PersistantData.Instance.names;
        int[] highScores = PersistantData.Instance.highScores;
        for (int i = 0; i < 9; i++)
        { 
                tempString += names[i] +":  "+ highScores[i] + "\n"; 
        }
        HighScores = tempString;
        highScoreText.text = HighScores;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backScene()
    {
        SceneManager.LoadScene(0);
    }
}
