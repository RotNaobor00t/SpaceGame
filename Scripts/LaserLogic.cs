using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public float LaserSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * LaserSpeed * Time.deltaTime);

        if(transform.position.y >= 6 || transform.position.y <= -6)
        {
            Component.Destroy(gameObject);
        }
    }

    public void SetEnemyLaserSettings()
    {
        LaserSpeed *= -0.5f;
    }
}
