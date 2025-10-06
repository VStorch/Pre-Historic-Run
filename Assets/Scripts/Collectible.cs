using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float speedMultiplier = 3f;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();    
    }

    void Update()
    {
        float speed = gm.speedMultiplier * speedMultiplier;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect -2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddPaca();
            Destroy(gameObject);
        }
    }
}
