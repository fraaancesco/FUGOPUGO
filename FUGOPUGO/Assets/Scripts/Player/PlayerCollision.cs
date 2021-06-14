using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameManager;
    void Awake()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Obstacle == 8
        if (collision.collider.gameObject.layer == 8)
        {
            SoundManager.Instance.ObstaclePlayer(collision.collider.tag);
            player.GetComponent<PlayerMovement>().Anim.SetBool("isGrounded", true);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameManager.GetComponent<GameManager>().EndGame();
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

