using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLogic : MonoBehaviour
{
    private float timeRemaining = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
