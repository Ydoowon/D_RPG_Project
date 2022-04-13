using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSpin : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float ChRotSpeed = 100.0f;
    public bool Is_Character_DragON = false;
    

    public void OnDrag(PointerEventData eventData)
    {
        Is_Character_DragON = true;
        float x = eventData.delta.x * Time.deltaTime * ChRotSpeed;
        transform.Rotate(0, -x, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Is_Character_DragON = false;
    }
}