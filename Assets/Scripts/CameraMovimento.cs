using UnityEngine;

public class CameraMovimento : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float positionY = player.position.y;
        float positionX = player.position.x;
        Vector3 startPosition = new Vector3(player.position.x, player.position.y, -1f);

        if (player.position.y <= 1.4f)
            positionY = 0f;
        if (player.position.y > 1.4f && player.position.y < 5f)
            positionY = player.position.y - 1f;
        if (player.position.y >= 8.5f)
            positionY = 8.5f;

        if (player.position.x >= 41f)
            positionX = 41f;
        else if (player.position.x < 41f)
            positionX = player.position.x;
         if (player.position.x <= -1f)
            positionX = -1f;
        
        startPosition = new Vector3(positionX, positionY, -1f);
        transform.position = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
    }
}