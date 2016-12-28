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
        CreateDraggingSlot();

        FillWithSlots(slotsContainer);
	}

    private void CreateDraggingSlot()
    {
        GameObject item = CreateSlot(dragAndDropObject.gameObject);
        Destroy(item.GetComponent<DragSourceHandler>());
        item.GetComponent<Image>().enabled = false;
        item.name = "itemBeingDragged";
        DragSourceHandler.itemBeingDragged = item;
        item.SetActive(false);
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
        }
    }
}
