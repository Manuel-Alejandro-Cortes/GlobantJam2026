using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyArea : MonoBehaviour
{
    [Header("Configuración de Escena")]
    [Tooltip("Asegúrate de que el nombre coincida exactamente con tu escena en Build Settings")]
    public string nombreEscenaGameOver = "GameOver";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto que entró tiene el Tag "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jugador alcanzado. Cargando GameOver...");

            // Cargamos la escena de derrota
            SceneManager.LoadScene(nombreEscenaGameOver);
        }
    }
}
