using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLogic_Impossible : MonoBehaviour
{
    public void SetSettings()
    {
        GameSettings.enemyCount = 100;
        GameSettings.initialSpawnSpeed = 0.6f;
        GameSettings.spawnAccelerationCoefficient = 0.2f;
        GameSettings.playerHealthCount = 3;
    }
}
