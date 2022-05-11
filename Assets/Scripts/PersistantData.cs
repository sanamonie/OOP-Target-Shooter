using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistantData : MonoBehaviour
{
   public static PersistantData Instance;

    public int[] highScores;
    public string[] names;

    private string playerName;
    public string PlayerName
    {
        get {
            return playerName;
        }
        set {
            playerName = value;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void getHighScores() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScores data = JsonUtility.FromJson<HighScores>(json);
            names = data.names;
            highScores = data.highScores;
        }
        else
        {
            names = new string[10];
            highScores = new int[10];
            for (int i = 0; i < 10; i++) 
            {
                names[i] = "no Name";
                highScores[i]=0;
            }
        }
    }

    public void addHighScore(int newScore)
    {
        if (newScore > highScores[9]) {
            names[9] = playerName;
            highScores[9] = newScore;
        }
        SortHighScores();
    }

    public void SortHighScores()
    {
        for (int i = 9; i >0; i--) {
            if (highScores[i] > highScores[i - 1])
            {
                //store 8's value
                int tempscore = highScores[i - 1];
                string tempName = names[i - 1];
                

                //make 8 equal 9's value
                highScores[i - 1] = highScores[i];
                names[i - 1] = names[i];

                // set 9 to 8's original value
                highScores[i] = tempscore;
                names[i] = tempName;
            }
            else {
                break;
            }

        }
    }

    public void saveHighScores()
    {
        if (names == null || highScores == null) {
            getHighScores();
        }
        HighScores data = new HighScores();
        data.names = names;
        data.highScores = highScores;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }


    public class HighScores {
        public int[] highScores;
        public string[] names;
    }
}
