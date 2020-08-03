using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLogic_Easy : MonoBehaviour
{
    public void SetSettings()
    {
        GameSettings.enemyCount = 30;
        GameSettings.initialSpawnSpeed = 0.4f;
        GameSettings.spawnAccelerationCoefficient = 0.05f;
        GameSettings.playerHealthCount = 5;
    }
}
