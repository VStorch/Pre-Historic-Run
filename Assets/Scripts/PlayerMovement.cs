using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead) return;

        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
            anim.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Slide");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        rb.velocity = Vector2.zero;
        Invoke(nameof(RestartLevel), 0.4f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}