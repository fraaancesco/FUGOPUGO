using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        targetPlayer = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = targetPlayer.position + offset ;   
    }
}
