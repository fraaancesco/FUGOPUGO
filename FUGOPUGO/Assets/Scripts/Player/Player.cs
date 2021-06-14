using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/*
[Serializable]
public  class Player : MonoBehaviour
{
    public PlayerData player = new PlayerData();
    
}
*/
[Serializable]
public class PlayerData
{
    public string namePlayer;
    public int wallet;
    public int levelPassed;
    public double[] score = new double[3];
    public int IndexSkin; // tiene conto della skin selezionata 
    public bool[] skinUnlocked = new bool[4];

}
