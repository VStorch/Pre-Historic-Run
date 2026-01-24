using UnityEngine;

public class MagnetPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            GameManager.Instance.ActivateMagnet();
            Destroy(gameObject);
        }
    }
}
