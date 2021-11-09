using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public InputField nameInput;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = $"ALL HAIL {Persistence.Instance.highScoreName} FOR THEY ARE A GOD AMONG MORTALS WITH {Persistence.Instance.highScore} POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewNameEntered(string Name){
        Persistence.Instance.playerName = Name;
    }

    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        
    }

    public void StartGame(){
        if(nameInput.text.Length != 0){
            Debug.Log(Persistence.Instance.playerName);
            NewNameEntered(nameInput.text);
        }
        SceneManager.LoadScene(1);
    }
}
