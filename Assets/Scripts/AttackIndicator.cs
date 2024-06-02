using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIndicator : MonoBehaviour
{
    public GameObject attackBar;
    public float attackBarLength;
    public float moveSpeed;
    private Rigidbody2D rb;

    string currentSection = "";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer attackBarSR = attackBar.GetComponent<SpriteRenderer>();
        attackBarLength = attackBarSR.bounds.size.x;
        rb.velocity = new Vector2(moveSpeed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is assuming attack bar is centered at 0
        if (transform.position.x <= -attackBarLength/2 ||
            transform.position.x >= attackBarLength/2) {
            moveSpeed *= -1;                                       //very bad i want to change
            if (transform.position.x <= -attackBarLength/2)
                transform.position = new Vector2(-attackBarLength/2 + Mathf.Epsilon, transform.position.y);
            else
                transform.position = new Vector2(attackBarLength/2 - Mathf.Epsilon, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            grade();
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentSection = other.gameObject.name;
    }

    void grade() 
    {
        Debug.Log(currentSection);
    }
}
