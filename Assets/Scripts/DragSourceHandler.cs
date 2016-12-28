using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof (Slot))]
public class DragSourceHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public static GameObject source;
    Vector3 startPosition;
    Vector3 mousePositionOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        source = gameObject;
        Slot sourceSlot = gameObject.GetComponent<Slot>();

        if (itemBeingDragged == null) CreateItem();

        Slot targetSlot = itemBeingDragged.GetComponent<Slot>();
        targetSlot.SetItem(sourceSlot.GetItem());

        itemBeingDragged.SetActive(true);

        startPosition = transform.position;
        mousePositionOffset = startPosition - Input.mousePosition;
    }

    private void CreateItem()
    {
        itemBeingDragged = GameObject.Find("Inventory").GetComponent<Inventory>().CreateDraggingSlot();
        // TODO: fit to the prefab size, find where to get these numbers from
        itemBeingDragged.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // TODO: align to the mouse
        itemBeingDragged.transform.position = Input.mousePosition - mousePositionOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged.SetActive(false);
    }
}
