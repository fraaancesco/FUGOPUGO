using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuSoundButton : MonoBehaviour, IPointerEnterHandler
{ 
    public void OnPointerEnter(PointerEventData pointerEvent)
    {

        if (pointerEvent.pointerEnter.gameObject.GetComponent<Button>()?.interactable is true && pointerEvent.pointerEnter.gameObject.layer == 5)
        {
            SoundManager.Instance.ButtonHover();
        }

    }

}