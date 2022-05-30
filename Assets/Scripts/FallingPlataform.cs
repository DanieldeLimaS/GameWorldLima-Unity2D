using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D _target;

    private BoxCollider2D _boxColider;

    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<TargetJoint2D>();
        _boxColider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Falling), fallingTime);
        }
    }
    void Falling()
    {
        _target.enabled = false;
        _boxColider.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    
}