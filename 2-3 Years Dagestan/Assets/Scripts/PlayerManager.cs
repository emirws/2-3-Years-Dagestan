using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public float speed = 5f;
    Vector3 startScale;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        // Hareket
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);

        // MOVE animasyonu
        anim.SetBool("1_Move", Mathf.Abs(h) > 0.1f);

        // Yön çevirme (DOĞRU)
        if (h > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(startScale.x),
                startScale.y,
                startScale.z
            );
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(startScale.x),
                startScale.y,
                startScale.z
            );
        }

        // ATTACK
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("2_Attack");
        }
    }
}