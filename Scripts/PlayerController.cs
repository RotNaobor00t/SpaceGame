using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput = 0;
    private float VerticalInput = 0;
    private float NextFireTime = 0;
    private int points;
    private int pointsToWin;
    private AudioSource laserShoot;

    [SerializeField]
    private AudioClip destroyShip;
    [SerializeField]
    private float PlayerSpeed = 5;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject level;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private int healthCount;
    [SerializeField]
    private GameObject playerExplosionPrefab;

    void Start()
    {
        transform.position = new Vector3(0,-3,0);
        laserShoot = GetComponent<AudioSource>();
    }

    void Update()
    {
        AddActorMovementInput();

        if (Input.GetMouseButton(0) && NextFireTime <= Time.time) { 
            Instantiate(laserPrefab, transform.position + new Vector3(0.005f, 1.4f, 0), Quaternion.identity);
            laserShoot.Play();
            NextFireTime = Time.time + 1/attackSpeed;
        }
    }

    public void AddActorMovementInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * PlayerSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * VerticalInput * PlayerSpeed);

        if (transform.position.y < -4)
        {
            transform.position = new Vector2(transform.position.x, -4);
        }
        else if (transform.position.y > 0)
        {
            transform.position = new Vector2(transform.position.x, 0);
        }

        if (transform.position.x < -8)
        {
            transform.position = new Vector2(-8, transform.position.y);
        }
        else if (transform.position.x > 8)
        {
            transform.position = new Vector2(8, transform.position.y);
        }
    }

    public void AddPoints()
    {
        if(++points == pointsToWin)
        {
            LevelLogic thisLevel = level.GetComponent<LevelLogic>();
            thisLevel.WinGame();
        }
    }

    public void SetPointsToWin(int newValue)
    {
        pointsToWin = newValue;
    }

    public void SetHealthCount(int count)
    {
        healthCount = count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            if (--healthCount <= 0)
            {
                
                AudioSource.PlayClipAtPoint(destroyShip, transform.position, 1.0f);
                LevelLogic thisLevel = level.GetComponent<LevelLogic>();
                GameObject.Destroy(this.gameObject);
                thisLevel.GameOver();
            }            
            GameObject.Destroy(collision.gameObject);            
        }
        else { print("delete error"); }
    }

}
