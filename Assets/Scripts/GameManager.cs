using UnityEngine;
using TMPro; // Importante para usar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  

    [Header("UI")]
    public TMP_Text textoMonedas;

    private int monedas = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarMonedas()
    {
        monedas++;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedas;
        }
    }
}
