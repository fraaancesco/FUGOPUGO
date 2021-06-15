using System;

[Serializable]
public class PlayerData
{
    public string namePlayer;
    public int wallet;
    public int levelPassed;
    public double[] score = new double[3];
    public int indexSkin;
    public bool[] skinUnlocked = new bool[4];

}
