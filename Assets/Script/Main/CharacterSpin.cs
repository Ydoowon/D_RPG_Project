using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSpin : MonoBehaviour, IDragHandler
{
    public float ChRotSpeed = 100.0f;
    
    

    public void OnDrag(PointerEventData eventData)
    {

        float x = eventData.delta.x * Time.deltaTime * ChRotSpeed;
        transform.Rotate(0, -x, 0);
    }
    
    
}