using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speedMultiplier;
    private GameManager gm;

    private Transform[] backgrounds;
    private float backgroundWidth;

    void Start()
    {
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        gm = GameManager.Instance;

    }

    void Update()
    {
        float speed = gm.speedMultiplier * speedMultiplier;

        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector2.left * speed * Time.deltaTime);
        }

        Transform first = backgrounds[0];
        Transform last = backgrounds[backgrounds.Length - 1];

        float halfWidth = backgroundWidth / 2f;
        float leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        if (first.position.x + halfWidth < leftBound)
        {
            Vector3 pos = first.position;
            pos.x = last.position.x + backgroundWidth;
            first.position = pos;

            for (int i = 0; i < backgrounds.Length - 1; i++)
            {
                backgrounds[i] = backgrounds[i + 1];
            }
            backgrounds[backgrounds.Length - 1] = first;
        }
    }
}
