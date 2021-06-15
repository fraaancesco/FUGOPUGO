using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] protected bool isOnMovementX;
    [SerializeField] protected bool isOnMovementY;
    [SerializeField] protected bool isOnRotation;

    protected Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        OnStart();
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void Move()
    {
        if(isOnMovementX)
        {
            Debug.Log("Moviment obstacle X");
        }else if(isOnMovementY)
        {
            Debug.Log("Moviment obstacle Y");
        }
    }

    protected virtual void Rotate()
    {
        if(isOnRotation)
        {
            Debug.Log("Rotation obstacle");
        }
    }

}
