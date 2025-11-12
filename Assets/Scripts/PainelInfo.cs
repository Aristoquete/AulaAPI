using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI info;
    private GameApiService api;
    [SerializeField] private GameObject panel;
    [SerializeField] private PlayerController playerControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        api = new GameApiService();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!panel.activeSelf)
            {
                panel.SetActive(true);
                AtualizarInfo();
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }

    async void AtualizarInfo()
    {
        Jogador player = playerControl.player;

        playerControl.AlterarPosi();
        
        player = await api.AtualizarJogador("1", player);

        info.text = $"Vida: {player.Vida}" +
            $"\n Quantidade Itens: {player.QuantidadeItens}" +
            $"\n Posição: " +
            $"X: {player.PosicaoX}, Y: {player.PosicaoY}, Z: {player.PosicaoZ}";
    }

    public async void BotãoRecarregar()
    {
        Jogador player = await api.GetJogador("1");
        player.Vida = 10;
        player.QuantidadeItens = 0;
        player.PosicaoY = 0;
        player.PosicaoZ = 0;
        player.PosicaoX = 0;
        await api.AtualizarJogador("1", player);

        SceneManager.LoadScene(0);
    }

    void OnDestroy()
    {
        api?.Dispose();
    }
}
