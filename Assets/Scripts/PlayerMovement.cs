using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float interactDistance;
    public Vector2 playerInput;
    public Vector2 interactVector;
    public LayerMask interactable;

    void Awake()
    {
        interactVector = new Vector2(interactDistance, 0);
    }

    void Update()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (playerInput != new Vector2(0, 0))
            interactVector = playerInput;
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.Space)) {
            interact();
        }
    }

    void FixedUpdate()
    {
        Vector2 moveForce = playerInput * moveSpeed;
        rb.velocity = moveForce;
    }

    void interact()
    {
        Debug.DrawRay(transform.position, interactVector, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, interactVector, interactDistance, interactable);
        if (hit.collider != null) {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.GetComponent<Job>().loadJob();
        }
    }
}