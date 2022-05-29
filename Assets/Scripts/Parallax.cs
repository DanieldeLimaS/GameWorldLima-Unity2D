using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _lenght;
    private float startPos;

    private Transform cam;

    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float reposBackGround = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (reposBackGround > startPos + _lenght)
            startPos += _lenght;
        else if(reposBackGround< startPos-_lenght)
            startPos -= _lenght;
    }
}