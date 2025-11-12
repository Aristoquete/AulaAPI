using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY;
    float altura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        altura = transform.position.y;
        altura += offsetY;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, altura, player.position.z);
         
    }
}
