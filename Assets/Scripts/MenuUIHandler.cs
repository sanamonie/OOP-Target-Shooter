using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PersistantData.Instance.getHighScores();
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGame() {
        PersistantData.Instance.PlayerName = GameObject.Find("NameField").GetComponent<InputField>().text;

        SceneManager.LoadScene(1);
    }
    public void enterHighScores()
    {
        SceneManager.LoadScene(2);
    }
}
