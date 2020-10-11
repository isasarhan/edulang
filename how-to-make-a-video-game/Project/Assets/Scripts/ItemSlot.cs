
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    private RectTransform rectTransform;
    private bool isRight = false;
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            rectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            if (rectTransform.tag != GetComponent<RectTransform>().tag && rectTransform.tag.Equals("Hatha"))
            {
                rectTransform.anchoredPosition = new Vector2(811, 98);
                return;
            } 
            if (rectTransform.tag != GetComponent<RectTransform>().tag && rectTransform.tag.Equals("Hathehe")) {
                rectTransform.anchoredPosition = new Vector2(811, -179.6f);
                return;
            }
			else
			{
				if (!isRight)
				{
                    isRight = true;
                    Scene2GameManager.score += 1;
                }
                rectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
            }
                
        }
        
    }

}
