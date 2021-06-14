using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endTrigger : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) 
        {
            GameManager.Instance.CompleteLevel();
           // SoundManager.Instance.LevelEnd();
        }
    }

    
   
}
