using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgbd;
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private GameObject painelSalvar;

    private GameApiService api;
    public Jogador player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        painelSalvar = GameObject.Find("salvamento");
        painelSalvar.SetActive(false);
        rgbd = GetComponent<Rigidbody>();
        api = new GameApiService();
        player = await api.GetJogador("1");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = transform.right * horizontal + transform.forward * vertical;
        Vector3 velocity = new Vector3(direction.x * speed, rgbd.linearVelocity.y, direction.z * speed);
        rgbd.linearVelocity = velocity;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("moeda"))
        {
            painelSalvar.SetActive(true);
            StartCoroutine(TempoSalvar());
        }
    }

    IEnumerator TempoSalvar()
    {
        yield return new WaitForSeconds(2f);
        painelSalvar.SetActive(false);
    }
    public void AlterarPosi()
    {
        player.PosicaoY = (int)transform.position.y;
        player.PosicaoX = (int)transform.position.x;
        player.PosicaoZ = (int)transform.position.z;
    }
}
