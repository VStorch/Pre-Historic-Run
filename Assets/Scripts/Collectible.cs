using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float speedMultiplier = 3f;
    private GameManager gm;
    private Camera cam;

    void Start()
    {
        gm = GameManager.Instance; 
        cam = Camera.main;
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

        if (transform.position.x < -cam.orthographicSize * cam.aspect - 2f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.pacaClip);
            GameManager.Instance.AddPaca();
            Destroy(gameObject);
        }
    }
}
