using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationMover : MonoBehaviour
{

    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect - 2f)
        {
            Destroy(gameObject);
        }

    }
}
