using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private GameManager gm;

    private float timer;

    void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6)
        {
            Destroy(gameObject);
        }

        rb.velocity = Vector2.left * (speed + gm.speedMultiplier);
    }
}
