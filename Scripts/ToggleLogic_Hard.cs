using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLogic_Hard : MonoBehaviour
{

    public void SetSettings()
    {
        GameSettings.enemyCount = 50;
        GameSettings.initialSpawnSpeed = 0.5f;
        GameSettings.spawnAccelerationCoefficient = 0.1f;
        GameSettings.playerHealthCount = 4;
    }

}
