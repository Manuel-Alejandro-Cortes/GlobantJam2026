using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración del Prefab")]
    public GameObject enemigoPrefab; // Arrastra tu Prefab aquí
    public Transform puntoDeSpawn;  // Opcional: lugar donde aparecerá (si no, usa la pos del Spawner)

    [Header("Configuración de Tiempo")]
    public float intervaloSpawn = 3f; // Cada cuántos segundos aparece
    public bool autoSpawn = false;     // ¿Empieza a spawnear solo?

    private float _timer;

    void Update()
    {
        if (autoSpawn)
        {
            // El cronómetro avanza con el tiempo real del juego
            _timer += Time.deltaTime;

            if (_timer >= intervaloSpawn)
            {
                SpawnEnemigo();
                _timer = 0; // Reiniciamos el cronómetro
            }
        }
    }

    // El método que pediste: se puede llamar desde aquí o desde otro script
    public void SpawnEnemigo()
    {
        if (enemigoPrefab != null)
        {
            // Si no asignaste un punto de spawn, usa la posición de este objeto
            Vector3 posicion = puntoDeSpawn != null ? puntoDeSpawn.position : transform.position;

            // Creamos el enemigo
            Instantiate(enemigoPrefab, posicion, Quaternion.identity);

            Debug.Log("¡Enemigo spawneado!");
        }
        else
        {
            Debug.LogWarning("EnemySpawner: No has asignado el prefab del enemigo.");
        }
    }
}
