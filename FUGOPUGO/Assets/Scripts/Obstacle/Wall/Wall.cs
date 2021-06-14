using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle
{
    protected override void OnStart()
    {
        isOnMovementX = false;
        isOnMovementY = false;
        isOnRotation = false;
        isCrazy = false;
    }
}
