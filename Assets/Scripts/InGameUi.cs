using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class InGameUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {      
    }

    public void ExitGame(){
        SceneManager.LoadScene(0);
    }
}