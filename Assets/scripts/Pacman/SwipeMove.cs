using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMove : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Move pcm;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                pcm.Inp(new Vector2(1,0));
            }
            if (eventData.delta.x < 0)
            {
                pcm.Inp(new Vector2(-1, 0));
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                pcm.Inp(new Vector2(0, 1));
            }
            if (eventData.delta.y < 0)
            {
                pcm.Inp(new Vector2(0, -1));
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
