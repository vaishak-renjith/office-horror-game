using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated = false;

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
    }
}
