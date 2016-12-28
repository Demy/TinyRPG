using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private InventoryItem item;
    private Image icon;
    private Text count;

    void Start()
    {
        icon = transform.Find("Image").gameObject.GetComponent<Image>();
        count = gameObject.GetComponentInChildren<Text>();

        DrawItem();
    }

    void Awake()
    {
        icon = transform.Find("Image").gameObject.GetComponent<Image>();
        count = gameObject.GetComponentInChildren<Text>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem giveItem = item;
        InventoryItem getItem = DragSourceHandler.itemBeingDragged.GetComponent<Slot>().GetItem();

        if (giveItem != null && getItem != null &&
            giveItem.name == getItem.name &&
            giveItem.count > 0 && getItem.count > 0)
        {
            item.count = getItem.count + giveItem.count;
            DrawItem();
            DragSourceHandler.source.GetComponent<Slot>().SetItem(null);
        }
        else
        {
            SetItem(getItem);
            DragSourceHandler.source.GetComponent<Slot>().SetItem(giveItem);
        }
    }

    public void SetItem(InventoryItem value)
    {
        item = value;

        DrawItem();
    }

    private void DrawItem()
    {
        bool hasItem = item != null;
        icon.enabled = hasItem;
        count.enabled = hasItem;
        if (hasItem)
        {
            var sprite = Resources.Load<Sprite>(item.icon);
            if (sprite != null) icon.sprite = sprite;
            count.text = item.count > 1 ? item.count.ToString() : "";
        }
    }

    public InventoryItem GetItem()
    {
        return item;
    }
}
