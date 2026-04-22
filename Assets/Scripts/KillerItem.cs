using UnityEngine;

public class KillerItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Znajdü skrypt kolektora gracza, øeby pobraÊ wynik
            PlayerCollector player = other.GetComponent<PlayerCollector>();
            // Znajdü GameManager i wywo≥aj koniec gry
            FindObjectOfType<GameManager>().EndGame(player.collectedItems);

            Destroy(gameObject);
        }
    }
}