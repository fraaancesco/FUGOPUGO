using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static void Spawn(this Transform trans, Transform spawnPoint)
    {
        trans.position = spawnPoint.position;
        trans.rotation = spawnPoint.rotation;
        trans.gameObject.SetActive(true);
    }

    public static void Spawn(this Transform trans, Vector3 spawnPoint)
    {
        trans.position = spawnPoint;
        trans.gameObject.SetActive(true);
    }
}
