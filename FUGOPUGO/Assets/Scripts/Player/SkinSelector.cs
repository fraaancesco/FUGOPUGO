using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkinSelector : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    private int currentSkinIndex;
    [SerializeField] skinBlueprint[] skins;
    
    private void Start()
    {
        currentSkinIndex = SaveGame.getIndexSkin();
        
        //setto tutti i cubi false
        foreach (GameObject cube in cubes)
        {
            cube.SetActive(false);
            Debug.Log(currentSkinIndex + "In gioco");
        }
        //attivo il cubo selezionato
        cubes[currentSkinIndex].SetActive(true);
    }
}
