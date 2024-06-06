using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public string itemLore;
    private int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public Sprite emptySprite;

    public TMP_Text quantityText;
    public Image itemImage;
    public GameObject selectedHighlight;

    public Image itemDescImg;
    public TMP_Text itemDescName;
    public TMP_Text itemDesc;

    public bool selected;

    public InventoryManager im;

    void Start()
    {
        im = FindObjectOfType<InventoryManager>(true);
        itemDesc.text = "";
        itemDescName.text = "";
    }


    public void addItem(string itemName, int quantity, Sprite itemSprite, string itemLore) 
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemName = itemName;
        this.itemLore = itemLore;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick();
        }
    }

    public void onLeftClick()
    {
        selected = !selected;
        im.deselectAllSlots();
        selectedHighlight.SetActive(selected);
        itemDescName.text = itemName;
        itemDesc.text = itemLore;
        itemDescImg.sprite = itemSprite;
        if (itemDescImg.sprite == null) {
            itemDescImg.sprite = emptySprite;
        }
        im.selectedSprite = itemSprite;
    }

    public void onRightClick()
    {

    }
}
