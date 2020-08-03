using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButtonLogic : MonoBehaviour
{
    public void SwitchSceneToMainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
