using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject cursorWithItem;
    public Sprite selectedSprite;
    private bool menuActivated = false;
    public bool itemActive = false;
    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.SetActive(menuActivated);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            menuActivated = !menuActivated;
            Debug.Log(menuActivated);
            InventoryMenu.SetActive(menuActivated);
        }
        if (selectedSprite != null && !menuActivated) {
            cursorWithItem.SetActive(true);
            cursorWithItem.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 
            cursorWithItem.transform.position = mousePosition;
        } else {
            cursorWithItem.SetActive(false);
        }
    }

    public void addItem(string itemName, int quantity, Sprite itemSprite, string itemLore) 
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].addItem(itemName, quantity, itemSprite, itemLore);
                itemSlot[i].transform.GetChild(2).gameObject.SetActive(true);
                return;
            }
        }
    }

    public void deselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
