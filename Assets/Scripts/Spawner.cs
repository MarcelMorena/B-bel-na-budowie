using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Ustawienia Obiektu")]
    public GameObject objectPrefab;
    public GameObject badObjectPrefab;
    public float objectLifetime = 5f;

    [Header("Ustawienia Trudnoœci (Startowe)")]
    public float initialSpawnRate = 2f;      // Co ile sekund na pocz¹tku
    public float initialBadItemChance = 10f; // Szansa na z³y przedmiot na pocz¹tku (%)

    [Header("Skalowanie Trudnoœci")]
    public float difficultyIncreaseSpeed = 0.05f; // Jak szybko gra staje siê trudniejsza
    public float minSpawnRate = 0.2f;            // Maksymalna prêdkoœæ (nie szybciej ni¿ co 0.2s)
    public float maxBadItemChance = 50f;         // Maksymalna szansa na z³y przedmiot (%)

    [Header("Obszar")]
    public Vector3 spawnArea = new Vector3(10f, 0f, 0f);

    // Zmienne wewnêtrzne
    private float currentSpawnRate;
    private float currentBadItemChance;
    private float spawnTimer;
    private float timeElapsed;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        currentBadItemChance = initialBadItemChance;
        spawnTimer = currentSpawnRate; // Zacznij od razu od spawnu
    }

    void Update()
    {
        // 1. Liczymy czas gry
        timeElapsed += Time.deltaTime;

        // 2. Skalujemy parametry trudnoœci
        // Prêdkoœæ: zmniejszamy czas miêdzy spawnami (Mathf.Max pilnuje, ¿eby nie spad³o poni¿ej minimum)
        currentSpawnRate = Mathf.Max(minSpawnRate, initialSpawnRate - (timeElapsed * difficultyIncreaseSpeed));

        // Szansa: zwiêkszamy procent (Mathf.Min pilnuje, ¿eby nie przekroczy³o maksimum)
        currentBadItemChance = Mathf.Min(maxBadItemChance, initialBadItemChance + (timeElapsed * difficultyIncreaseSpeed * 5f));

        // 3. Logika timera do spawnowania
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = currentSpawnRate; // Resetujemy timer do aktualnej (nowej) prêdkoœci
        }
    }

    void SpawnObject()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f),
            Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f),
            0
        );

        Vector3 spawnPosition = transform.position + randomOffset;

        // U¿ywamy aktualnej szansy (currentBadItemChance)
        GameObject prefabToSpawn = (Random.Range(0f, 100f) < currentBadItemChance) ? badObjectPrefab : objectPrefab;

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, transform.rotation);
        Destroy(spawnedObject, objectLifetime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, spawnArea);
    }
}