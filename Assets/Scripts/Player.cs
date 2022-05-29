using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] public float speed;
    [FormerlySerializedAs("JumpForce")] public float jumpForce;

    public bool isJumping;
    public bool doubleJump;

    public Rigidbody2D rdb2D;
    private Animator _animator;
    private static readonly int Andando = Animator.StringToHash("Andando");
    private static readonly int Pulando = Animator.StringToHash("Pulando");

    // Start is called before the first frame update
    void Start()
    {
        rdb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * speed);

        if (Input.GetAxis("Horizontal") > 0f) //player andando para direita
        {
            _animator.SetBool(Andando, true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f) //player andando para Esquerda
        {
            _animator.SetBool(Andando, true);
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            _animator.SetBool(Andando, false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rdb2D.AddForce(new Vector2(0f, jumpForce * 1.19f), ForceMode2D.Impulse);
                doubleJump = true;
                _animator.SetBool(Pulando, true);
            }
            else if (doubleJump)
            {
                rdb2D.AddForce(new Vector2(0f, jumpForce / 2f), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) //detecta toda vez que o player bate em algo
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = false;
            _animator.SetBool(Pulando, false);
        }

        if (col.gameObject.CompareTag("Espinho"))
        {
           GameController.Instance.ShowGameOver();
           Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
           col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
           _animator.SetTrigger("Pulo");
        }
        if (col.gameObject.CompareTag("Ganhou"))
        {
            GameController.Instance.ShowWinner();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}