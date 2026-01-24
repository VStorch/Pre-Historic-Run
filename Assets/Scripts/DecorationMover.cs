using UnityEngine;

public class DecorationMover : MonoBehaviour
{
    public float speed = 5f;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -cam.orthographicSize * cam.aspect - 2f)
        {
            Destroy(gameObject);
        }

    }
}
