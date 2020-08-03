using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private float NewPosition = 0;
    private bool isRightMovement = false;
    private float NextFireTime = 0;
    private GameObject newLaser;

    [SerializeField]
    private AudioClip destroyShip;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speedMax = 0;

    [SerializeField]
    private float speedMin = 0;

    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private GameObject enemyExplosionPrefab;

    [SerializeField]
    private GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
            
        isRightMovement = transform.position.x <= NewPosition ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 3.9f)
        {
            transform.Translate(Vector3.down * Random.Range(speedMin, speedMax) * Time.deltaTime);
        } else 
        {
            MoveSpaceship();
            MakeShoot();
        }

    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destroyShip, transform.position, 1.0f);
            PlayerController playerLogic = player.GetComponent<PlayerController>();
            playerLogic.AddPoints();
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collision.gameObject);
        }
        else { print("delete error"); }
    }

    private void MoveSpaceship()
    {
        if (isRightMovement && transform.position.x <= NewPosition)
        {
            transform.Translate(Vector3.right * Random.Range(speedMin, speedMax) * Time.deltaTime);
        }
        else if (!isRightMovement && transform.position.x >= NewPosition)
        {
            transform.Translate(Vector3.left * Random.Range(speedMin, speedMax) * Time.deltaTime);
        }
        else
        {
            NewPosition = Random.Range(-7.5f, 7.5f);
            isRightMovement = transform.position.x <= NewPosition ? true : false;
        }
    }

    private void MakeShoot()
    {
        if (NextFireTime <= Time.time)
        {
            newLaser = Instantiate(laserPrefab, transform.position + new Vector3(0.005f, -1.5f, 0), Quaternion.identity);
            LaserLogic laser = newLaser.GetComponent<LaserLogic>();
            if (laser!=null)
                    laser.SetEnemyLaserSettings();
            NextFireTime = Time.time + 1 / attackSpeed;
        }
    }
    
}
