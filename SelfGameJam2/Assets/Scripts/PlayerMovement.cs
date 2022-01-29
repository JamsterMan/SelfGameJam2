using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float playerHorizontalUpperBound;
    public float playerHorizontalLowerBound;
    public float playerVerticalUpperBound;
    public float playerVerticalLowerBound;

    public Animator playerAnimator;

    private Rigidbody2D rb;

    private Vector2 movement;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        movement.y = Input.GetAxisRaw("Vertical") * moveSpeed;

        if (movement.x != 0 || movement.y != 0)
        {

            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

            playerAnimator.SetFloat("Horizontal", movement.x);
            playerAnimator.SetFloat("Vertical", movement.y);

            Vector3 pos = transform.position;

            pos.x = Mathf.Clamp(pos.x, playerHorizontalLowerBound, playerHorizontalUpperBound);
            pos.y = Mathf.Clamp(pos.y, playerVerticalLowerBound, playerVerticalUpperBound);

            transform.position = pos;

            audioManager.PlaySound("PlayerWalking");
        }
    }
}
