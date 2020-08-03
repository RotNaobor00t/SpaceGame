using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    private float spawnSpeed;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemyPrefab;
    
    [SerializeField]
    private float initialSpawnSpeed;
    
    [SerializeField]
    private float spawnAccelerationCoefficient;

    [SerializeField]
    private int enemyCount;

    void Start()
    {
        // Setup enemy
        spawnSpeed = initialSpawnSpeed;
        EnemyLogic enemy = enemyPrefab.GetComponent<EnemyLogic>();
        enemy.SetPlayer(player);


        PlayerController mainPlayer = player.GetComponent<PlayerController>();
        

        //Setup difficulty
        enemyCount = GameSettings.enemyCount;
        initialSpawnSpeed = GameSettings.initialSpawnSpeed;
        spawnAccelerationCoefficient = GameSettings.spawnAccelerationCoefficient;
        mainPlayer.SetHealthCount(GameSettings.playerHealthCount);
        mainPlayer.SetPointsToWin(enemyCount);

        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        StartCoroutine(waitToChangeScene("GameOver"));
    }

    public void WinGame()
    {
        StartCoroutine(waitToChangeScene("WinGame"));
    }

    IEnumerator waitToChangeScene(string newScene)
    {

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(newScene);

    }

    private IEnumerator SpawnEnemies()
    {
        for(int i=0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0), Quaternion.identity);
            
            yield return new WaitForSeconds(1 / spawnSpeed);
            spawnSpeed += spawnAccelerationCoefficient * initialSpawnSpeed;
        }
    }

}
