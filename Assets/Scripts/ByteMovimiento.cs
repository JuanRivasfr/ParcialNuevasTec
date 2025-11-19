using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float velocidadCorrer = 8f; // 🔹 Nueva velocidad al correr
    public float fuerzaSalto = 7f;

    [Header("Detección de suelo")]
    public LayerMask capaSuelo;
    public Transform puntoSuelo;
    public float radioSuelo = 0.1f;

    [Header("Salto más natural")]
    public float multiplicadorCaida = 2f;
    public float multiplicadorSaltoCorto = 2f;

    [Header("Coyote time (opcional)")]
    public float tiempoCoyote = 0.1f;
    private float coyoteTimer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool enSuelo;
    private bool corriendo; // 🔹 Nuevo flag para saber si está corriendo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // ------------------------------
        // Detección de suelo
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        if (enSuelo)
            coyoteTimer = tiempoCoyote;
        else
            coyoteTimer -= Time.deltaTime;

        // ------------------------------
        // Movimiento horizontal
        float movimiento = Input.GetAxisRaw("Horizontal");

        // 🔹 Detectar si está corriendo (mantiene Shift)
        corriendo = Input.GetKey(KeyCode.LeftShift) && movimiento != 0;

        // 🔹 Cambiar velocidad según estado
        float velocidadActual = corriendo ? velocidadCorrer : velocidad;

        rb.velocity = new Vector2(movimiento * velocidadActual, rb.velocity.y);

        // Cambiar dirección del sprite
        if (movimiento != 0)
            sr.flipX = movimiento < 0;

        // ------------------------------
        // Saltar (usa coyote time)
        if (Input.GetButtonDown("Jump") && coyoteTimer > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            coyoteTimer = 0;
        }

        // ------------------------------
        // Gravedad personalizada
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadorCaida - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadorSaltoCorto - 1) * Time.deltaTime;
        }

        // ------------------------------
        // Animaciones
        animator.SetFloat("Velocidad", Mathf.Abs(movimiento));
        animator.SetBool("EnSuelo", enSuelo);
        animator.SetBool("Corriendo", corriendo); // 🔹 Nueva animación para correr
    }

    // Visualizar punto de suelo
    void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }

    [Header("Monedas")]
    public int monedas = 0;
    public HUDMonedas hudMonedas;

    public void AgregarMonedas(int cantidad)
    {
        monedas += cantidad;
        hudMonedas.ActualizarMonedas(monedas);
    }


}
