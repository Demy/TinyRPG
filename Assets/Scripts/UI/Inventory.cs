using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public Transform slotTemplate;
    public Transform dragAndDropObject;
    public GameObject slotsContainer;
    public int slotCount;

    void Start ()
    {
        FillWithSlots(slotsContainer);
    }

    public GameObject CreateDraggingSlot()
    {
        GameObject item = CreateSlot(dragAndDropObject.gameObject);
        Destroy(item.GetComponent<DragSourceHandler>());
        //item.GetComponent<Image>().enabled = false;
        item.name = "itemBeingDragged";
        return item;
    }

    private GameObject CreateSlot(GameObject parentPanel)
    {
        Transform slotView = Instantiate(slotTemplate, new Vector3(), Quaternion.identity) as Transform;
        GameObject slot = slotView.gameObject;
        slotView.SetParent(parentPanel.transform, false);
        return slot;
    }

    private void FillWithSlots(GameObject container)
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = CreateSlot(container);
            slot.name = "Slot" + i.ToString();
            slot.GetComponent<Slot>().SetItem(CreateRandomItem());
        }
    }

    private InventoryItem CreateRandomItem()
    {
        InventoryItem testItem = null;
        float rand = Random.value;
        if (rand < 0.2)
        {
            testItem = new InventoryItem();
            testItem.name = "Small Sword";
            testItem.count = -1;
            testItem.icon = "smallSword";
        }
        else if (rand < 0.5)
        {
            testItem = new InventoryItem();
            testItem.name = "Blueberry";
            testItem.count = (int)(Random.Range(1f, 99f));
            testItem.icon = "blueberry";
        }
        else if (rand < 0.8)
        {
            testItem = new InventoryItem();
            testItem.name = "Cherry";
            testItem.count = (int)(Random.Range(1f, 99f));
            testItem.icon = "cherry";
        }
        return testItem;
    }
}
