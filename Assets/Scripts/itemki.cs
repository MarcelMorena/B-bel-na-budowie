using UnityEngine;
using TMPro; // Wymagane do obs³ugi nowego tekstu UI (TextMeshPro)

public class PlayerCollector : MonoBehaviour
{
    [Header("Statystyki")]
    public int collectedItems = 0;

    [Header("Interfejs (UI)")]
    public TextMeshProUGUI scoreText; // Miejsce, do którego przeci¹gniesz swój tekst z UI

    void Start()
    {
        // Ustawiamy pocz¹tkowy tekst na starcie gry
        UpdateScoreUI();
    }

    // Ta funkcja wywo³uje siê, gdy gracz wejdzie w obszar innego obiektu z zaznaczonym "Is Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, z którym siê zderzyliœmy, ma Tag "Collectible"
        if (other.CompareTag("Collectible"))
        {
            collectedItems++; // Zwiêkszamy licznik o 1
            UpdateScoreUI();  // Aktualizujemy tekst na ekranie

            // Niszczymy zebrany przedmiot (¿eby znikn¹³ z mapy)
            Destroy(other.gameObject);
        }
    }

    // Funkcja pomocnicza do odœwie¿ania tekstu na ekranie
    void UpdateScoreUI()
    {
        // Upewniamy siê, ¿e przypisaliœmy tekst w Inspektorze, ¿eby unikn¹æ b³êdów
        if (scoreText != null)
        {
            scoreText.text = "Zebrane: " + collectedItems;
        }
    }
}