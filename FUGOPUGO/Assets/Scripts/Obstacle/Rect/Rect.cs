using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rect : Obstacle
{
    protected override void OnStart()
    {
    }

    protected override void Move()
    {
        if (isOnMovementX)
        {
            anim.SetBool("MoveOnX", true);
        }else if(isOnMovementY)
        {
            anim.SetBool("MoveOnY", true);
        }
    }

    protected override void Rotate()
    {
        if(isOnRotation)
        {
            anim.SetBool("Rotate360", true);
        }
    }

    void Update()
    {
        Move();
        Rotate();
    }
}
