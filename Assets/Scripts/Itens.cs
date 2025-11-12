using NUnit.Framework.Interfaces;
using UnityEngine;

public class Itens : MonoBehaviour
{
    private GameApiService api;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        api = new GameApiService();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SaveItens();
            Destroy(this.gameObject);
        }
    }

    private void SaveItens()
    {
        Jogador player = FindFirstObjectByType<PlayerController>().player;
        player.QuantidadeItens++;
        
    }
}
