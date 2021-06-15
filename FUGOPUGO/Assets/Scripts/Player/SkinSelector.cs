using UnityEngine;
public class SkinSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    private int currentSkinIndex;
    [SerializeField] private SkinBluePrint[] skins;
    
    private void Start()
    {
        currentSkinIndex = SaveGame.getIndexSkin();

        foreach (GameObject cube in cubes)
        {
            cube.SetActive(false);
        }
        
        cubes[currentSkinIndex].SetActive(true);
    }
}
