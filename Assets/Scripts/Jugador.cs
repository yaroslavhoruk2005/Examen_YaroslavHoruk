using UnityEngine;
using UnityEngine.InputSystem;
public class Jugador : MonoBehaviour
{
    [Header("----------Movimiento----------")]
    public float velocidad = 5f;
    private float movimientoX;
    private Rigidbody2D rb2d;

    [Header("----------Salto----------")]
    public float fuerzaSalto = 7f;
    private bool enSuelo = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;

        if (movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
