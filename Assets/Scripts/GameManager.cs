using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Spawn Objects")]
    public GameObject[] groundEnemies;
    public GameObject[] flyingEnemies;
    public GameObject collectible;

    [Header("Spawn Points")]
    public GameObject[] spawnPoints;
    public Transform collectibleSpawnPoint;

    [Header("Spawn Time")]
    public float timer;
    public float timeBetweenSpawns;

    [Header("Power-Ups")]
    public GameObject magnetPowerUp;
    public Transform magnetSpawnPoint;

    private float magnetTimerSpawn;
    private float magnetSpawnInterval;
    public bool isMagnetActive;
    public float magnetDuration = 5f;
    private float magnetTimer;

    [Header("Player")]
    public Animator playerAnimator;
    public Transform playerTransform;
    public float speedMultiplier;
    private float distance;

    [Header("UI")]
    public Text distanceUI;
    public Text highScoreUI;
    public Text collectibleUI;

    private float highScore;
    private int pacas;

    private float collectibleTimer;
    private float collectibleSpawnTime;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0);
        pacas = PlayerPrefs.GetInt("pacas", 0);

        highScoreUI.text = "High Score: " + highScore.ToString("F2");
        collectibleUI.text = "Pacas: " + pacas;

        timeBetweenSpawns = Random.Range(1f, 3f);
        collectibleSpawnTime = Random.Range(4f, 8f);
        magnetSpawnInterval = Random.Range(10f, 20f);
    }

    void Update()
    {
        // Score

        distanceUI.text = "Distance: " + distance.ToString("F2");
        collectibleUI.text = "Pacas: " + pacas;

        if (distance > highScore)
        {
            highScore = distance;
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        speedMultiplier += Time.deltaTime * 0.1f;
        playerAnimator.speed = (float)(1 + speedMultiplier * 0.1);
        timer += Time.deltaTime;
        distance += Time.deltaTime * 0.8f;

        // Enemies

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            timeBetweenSpawns = Random.Range(1f, 3f);

            int randomPoint = Random.Range(0, spawnPoints.Length);

            GameObject enemyToSpawn = null;

            if (randomPoint == 0)
            {
                int randomGround = Random.Range(0, groundEnemies.Length);
                enemyToSpawn = groundEnemies[randomGround];
            }
            else
            {
                int randomFlying = Random.Range(0, flyingEnemies.Length);
                enemyToSpawn = flyingEnemies[randomFlying];
            }

            Instantiate(enemyToSpawn, spawnPoints[randomPoint].transform.position, Quaternion.identity);
        }

        // Collectible

        collectibleTimer += Time.deltaTime;
        if (collectibleTimer > collectibleSpawnTime)
        {
            collectibleTimer = 0;
            collectibleSpawnTime = Random.Range(4f, 8f);
            Instantiate(collectible, collectibleSpawnPoint.position, Quaternion.identity);
        }

        // Power-Up

        magnetTimerSpawn += Time.deltaTime;
        if (magnetTimerSpawn > magnetSpawnInterval)
        {
            magnetTimerSpawn = 0;
            magnetSpawnInterval = Random.Range(10f, 20f);
            Instantiate(magnetPowerUp, magnetSpawnPoint.position, Quaternion.identity);
        }

        if (isMagnetActive)
        {
            magnetTimer -= Time.deltaTime;
            if (magnetTimer < 0)
                isMagnetActive = false;
        }
    }
    public void AddPaca()
    {
        pacas++;
        PlayerPrefs.SetInt("pacas", pacas);
        collectibleUI.text = "Pacas: " + pacas;
    }

    public void ActivateMagnet()
    {
        isMagnetActive = true;
        magnetTimer = magnetDuration;
    }
}
