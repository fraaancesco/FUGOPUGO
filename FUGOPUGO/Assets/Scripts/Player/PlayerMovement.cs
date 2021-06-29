using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; // RigidBody player
    [SerializeField] private float zForce; // Force vertical
    [SerializeField] private float xForce; // Force horizontal
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    protected Animator anim;
    protected GameObject GameManager;

    public Animator Anim
     {
        get { return anim; }
        set { anim = value;  }
     }

    public float ZForce
    {
        get { return zForce; }
        set { zForce = value;  }
    }

    public float XForce
    {
        get { return xForce; }
        set { xForce = value;  }
    }

    public float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value;  }
    }

    public bool Grounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    void Awake()
    {
        zForce = 20f;
        xForce = 20f;
        jumpForce = 7f;
        isGrounded = true;
        anim = GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        GameManager = GameObject.Find("GameManager");

    }

    void Update()
    {
        if (!GameManager.GetComponent<GameManager>().gameHasEnded)
        {
            Move();
            Jump();
            Crounched();
            PlayerDied();
        }
    }

    //private void Jump()
    //{
    //    if (Input.GetButtonDown("Jump") && isGrounded && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
    //    {
    //        rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
    //        Grounded = false;
    //        anim.SetBool("isJump", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("isJump", false);
    //    }

    //}

    //private void Move()
    //{
    //    // Move player vertical
    //    if (Input.GetAxisRaw("Vertical") > 0) 
    //    {
    //        rb.AddForce(0f, 0f, zForce * Time.deltaTime, ForceMode.VelocityChange);
    //    }
    //    else if (Input.GetAxisRaw("Vertical") < 0)
    //    {
    //        rb.AddForce(0f, 0f, -zForce * Time.deltaTime, ForceMode.VelocityChange);
    //    }

    //    // Move player horizontal
    //    if (Input.GetAxisRaw("Horizontal") < 0)
    //    {
    //        rb.AddForce(-xForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
    //    }
    //    else if(Input.GetAxisRaw("Horizontal") > 0)
    //    {
    //        rb.AddForce(xForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
    //    }
    //}

    //private void Crounched()
    //{
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        anim.SetBool("isCrounched", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("isCrounched", false);
    //    }
    //}

    private void Jump()
    {
        if (Input.GetKeyDown(InputManager.Instance.controls["jump"]) && isGrounded && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            Grounded = false;
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }

    }

    private void Move()
    {
        // Move player vertical
        if (Input.GetKey(InputManager.Instance.controls["forward"]))
        {
            rb.AddForce(0f, 0f, zForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(InputManager.Instance.controls["backward"]))
        {
            rb.AddForce(0f, 0f, -zForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Move player horizontal
        if (Input.GetKey(InputManager.Instance.controls["left"]))
        {
            rb.AddForce(-xForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(InputManager.Instance.controls["right"]))
        {
            rb.AddForce(xForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
    }

    private void Crounched()
    {
        if (Input.GetKey(InputManager.Instance.controls["crounched"]))
        {
            anim.SetBool("isCrounched", true);
        }
        else
        {
            anim.SetBool("isCrounched", false);
        }
    }

    // This function is called on Jump Animation Player
    public void SoundJumpActive()
    {
        SoundManager.Instance.JumpPlayer();
    }

    // This function is called on Crounched Animation Player
    public void SoundCrounchedActive()
    {
        SoundManager.Instance.CrouchPlayer();
    }


    private void PlayerDied()
    {
        if(rb.position.y < -4)
        {
            GameManager.GetComponent<GameManager>().EndGame();
        }else if(rb.position.y > 60)
        {
            GameManager.GetComponent<GameManager>().EndGame();
        }
    }
}
