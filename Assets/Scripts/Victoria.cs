using UnityEngine;
using UnityEngine.SceneManagement; 

public class VictoriaTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Victoria"))
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
