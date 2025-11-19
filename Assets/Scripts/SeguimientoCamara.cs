using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform jugador;

    private void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
        }
    }
}
