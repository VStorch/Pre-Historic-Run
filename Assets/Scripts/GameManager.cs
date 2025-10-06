using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Spawn Objects")]
    public GameObject[] groundEnemies;
    public GameObject[] flyingEnemies;

    [Header("Spawn Points")]
    public GameObject[] spawnPoints;

    [Header("Spawn Time")]
    public float timer;
    public float timeBetweenSpawns;

    [Header("Player")]
    public Animator playerAnimator;
    public float speedMultiplier;
    private float distance;

    [Header("UI")]
    public Text distanceUI;
    public Text highScoreUI;
    private float highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0);
        highScoreUI.text = "High Score: " + highScore.ToString("F2");

        timeBetweenSpawns = Random.Range(1f, 3f);
    }

    void Update()
    {
        distanceUI.text = "Distance: " + distance.ToString("F2");
        if (distance > highScore)
        {
            highScore = distance;
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        speedMultiplier += Time.deltaTime * 0.1f;
        playerAnimator.speed = (float)(1 + speedMultiplier * 0.1);
        timer += Time.deltaTime;
        distance += Time.deltaTime * 0.8f;

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
    }
}
