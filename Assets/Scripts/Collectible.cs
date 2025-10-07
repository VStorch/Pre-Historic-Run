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

        if (GameManager.Instance.isMagnetActive)
        {
            Vector3 direction = (gm.playerTransform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect - 2f)
            Destroy(gameObject);
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
