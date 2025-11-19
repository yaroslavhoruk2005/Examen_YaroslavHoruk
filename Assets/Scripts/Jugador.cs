using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Jugador : MonoBehaviour
{
    [Header("----------Movimiento----------")]
    public float velocidad = 5f;
    private float movimientoX;
    private Rigidbody2D rb2d;
    private bool mirandoDerecha = true;

    [Header("----------Salto----------")]
    public float fuerzaSalto = 7f;
    private bool enSuelo = false;
    public Transform comprobadorSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    [Header("----------Monedas----------")]
    public TMP_Text textoMonedas;     
    private int monedas = 0;

    [Header("----------Audio----------")]
    public AudioSource audioSource;   
    public AudioClip getMonedas;      
    public AudioSource musicaFondo;   
    public float volumenMusica = 0.5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (musicaFondo != null)
        {
            musicaFondo.loop = true;
            musicaFondo.volume = volumenMusica;
            musicaFondo.Play();
        }
    }

    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;
    }

    private void OnJump(InputValue inputSalto)
    {
        if (enSuelo)
        {
            rb2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioSuelo, capaSuelo);

        if (movimientoX > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (movimientoX < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            if (audioSource != null && getMonedas != null)
            {
                audioSource.PlayOneShot(getMonedas);
            }

            monedas++;
            ActualizarUI();

            Destroy(collision.gameObject);
        }
    }

    private void ActualizarUI()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedas;
        }
    }
}
