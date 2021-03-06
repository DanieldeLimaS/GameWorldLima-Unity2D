using UnityEngine;

public class ParallaxNuvem : MonoBehaviour
{
    private float startPos;

    private Transform cam;

    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

       
    }
}