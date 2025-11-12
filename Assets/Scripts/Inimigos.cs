using UnityEngine;

public class Inimigos : MonoBehaviour
{
    private GameApiService api;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        api = new GameApiService();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DanoInimigo();
        }
    }

    private void DanoInimigo()
    {
        Jogador player = FindFirstObjectByType<PlayerController>().player;
        player.Vida--;
        
    }
}
