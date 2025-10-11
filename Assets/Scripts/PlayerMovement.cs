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

        // PC

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Slide();
        }
#endif
        // Mobile
#if UNITY_ANDROID || UNITY_IOS
        HandleTouchInput();
#endif
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            if (touch.position.y > Screen.height / 2f && isGrounded)
            {
                Jump();
            }
            else
            {
                Slide();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jump);
        anim.SetTrigger("Jump");
    }

    private void Slide()
    {
        anim.SetTrigger("Slide");
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
        GameManager.Instance.GameOver();
    }
}