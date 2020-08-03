using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

static class GameSettings
{
    static public int enemyCount = 30;
    static public float initialSpawnSpeed = 0.4f;
    static public float spawnAccelerationCoefficient = 0.05f;
    static public int playerHealthCount = 5;
}

public class StartGameButtonLogic : MonoBehaviour
{
    void Start()
    {
        
    }

    public void SwitchSceneToMainGame()
    {
        SceneManager.LoadScene("SpaceGame");
    }
}
