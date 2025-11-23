using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool enSuelo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidad, rb.velocity.y);

        // Cambiar dirección del sprite
        if (movimiento != 0)
            sr.flipX = movimiento < 0;

        // Saltar (si está en el suelo)
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // Enviar velocidad al Animator
        animator.SetFloat("Velocidad", Mathf.Abs(movimiento));
        // Enviar estado de suelo al Animator
        animator.SetBool("EnSuelo", enSuelo);

    }

    // Detectar si está en el suelo
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            enSuelo = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            enSuelo = false;
    }
}
