using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int quantity;
    [TextArea]
    public string lore;

    public float amp = 0.5f;
    public float freq = 1f;
    Vector3 startPos;

    public InventoryManager im; //heh

    void Start()
    {
        im = FindObjectOfType<InventoryManager>(true);
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * freq) * amp;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collided");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collided with player");
            if (im != null)
                im.addItem(itemName, quantity, GetComponent<SpriteRenderer>().sprite, lore);
            Destroy(gameObject);
        }
    }
}
