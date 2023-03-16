using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    public Transform slotRoot;

    private List<Slot> slots;

    public System.Action<ItemProperty> onSlotClick;


    private void Start()
    {
        slots = new List<Slot>();

        int slotCount = slotRoot.childCount;

        for(int i = 0; i< slotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else
            {
                slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            slots.Add(slot); 
        }
    }

    private void Update()
    {
        
    }

    public void OnClickSlot(Slot slot)
    {
        if(onSlotClick != null)
        {
            onSlotClick(slot.item);
        }
    }
}
