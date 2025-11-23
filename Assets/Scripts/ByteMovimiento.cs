using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float velocidadCorrer = 8f;
    public float fuerzaSalto = 7f;

    [Header("Detección de suelo")]
    public LayerMask capaSuelo;
    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;

    [Header("Salto más natural")]
    public float multiplicadorCaida = 1.5f;
    public float multiplicadorSaltoCorto = 1.2f;

    [Header("Coyote time")]
    public float tiempoCoyote = 0.1f;
    private float coyoteTimer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool enSuelo;
    private bool corriendo;

    [Header("Monedas")]
    public int monedas = 0;
    public HUDMonedas hudMonedas;

    [Header("Llave")]
    public GameObject llaveEfectoPrefab;
    public bool tieneLlave = false; // 🔹 pública para que otros scripts puedan consultarla

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        if (enSuelo)
            coyoteTimer = tiempoCoyote;
        else
            coyoteTimer -= Time.deltaTime;

        float movimiento = Input.GetAxisRaw("Horizontal");
        corriendo = Input.GetKey(KeyCode.LeftShift) && movimiento != 0;

        float velocidadActual = corriendo ? velocidadCorrer : velocidad;
        rb.velocity = new Vector2(movimiento * velocidadActual, rb.velocity.y);

        if (movimiento != 0)
            sr.flipX = movimiento < 0;

        if (Input.GetButtonDown("Jump") && coyoteTimer > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            coyoteTimer = 0;
        }

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadorCaida - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (multiplicadorSaltoCorto - 1) * Time.deltaTime;

        animator.SetFloat("Velocidad", Mathf.Abs(movimiento));
        animator.SetBool("EnSuelo", enSuelo);
        animator.SetBool("Corriendo", corriendo);
    }

    public void AgregarMonedas(int cantidad)
    {
        monedas += cantidad;
        hudMonedas.ActualizarMonedas(monedas);

        // 🔹 Dar la llave al jugador al alcanzar 20 monedas
        if (monedas >= 20 && !tieneLlave)
        {
            // Instancia la llave un poco encima del jugador
            GameObject llave = Instantiate(llaveEfectoPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

            // Asigna el jugador a la llave para que siga dinámicamente
            LlaveMascota llaveMascota = llave.GetComponent<LlaveMascota>();
            if (llaveMascota != null)
                llaveMascota.jugador = transform;

            tieneLlave = true;
        }
    }
}