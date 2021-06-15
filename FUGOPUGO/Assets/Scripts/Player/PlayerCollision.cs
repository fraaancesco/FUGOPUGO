using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject GameManager;
    void Awake()
    {
        player = GameObject.Find("Player");
        GameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Obstacle.
        if (collision.collider.gameObject.layer == 8)
        {
            SoundManager.Instance.ObstaclePlayer(collision.collider.tag);
            player.GetComponent<PlayerMovement>().Anim.SetBool("isGrounded", true);
        }
        
        // Wall.
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.GetComponent<GameManager>().EndGame();
        }

        // Collision with the ground.
        if (collision.gameObject.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().Grounded = true;
            player.GetComponent<PlayerMovement>().Anim.SetBool("isGrounded", true);
            player.GetComponent<PlayerMovement>().Anim.SetBool("isJump", true);
        }
    }

}

