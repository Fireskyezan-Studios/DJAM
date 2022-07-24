using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	private RectTransform rectTransform;
	private GameObject canvas;
	private Canvas canvasThing;
	private CanvasGroup canvasGroup;

	private void Awake() {
		canvas = GameObject.Find("Canvas");
		canvasThing = canvas.GetComponent<Canvas>();
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log("Begin Drag");
		canvasGroup.alpha = .6f;
		canvasGroup.blocksRaycasts = false;
		GameObject.Find("Inventory").GetComponent<DisplayInventory>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
		GameObject.Find("Interact").GetComponent<DisplayInteraction>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
	}

	public void OnDrag(PointerEventData eventData) {
		Debug.Log("Drag");
		rectTransform.anchoredPosition += eventData.delta / canvasThing.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log("End Drag");
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;
	}

	public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Pointer Down");
	}



	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
