using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [Range(0.05f,0.3f)]
    public float smoothMove = 0.2f;

    public float playerHorizontalUpperBound;
    public float playerHorizontalLowerBound;
    public float playerVerticalUpperBound;
    public float playerVerticalLowerBound;

    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;

        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(horizontalMove, verticalMove), ref velocity, smoothMove);

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, playerHorizontalLowerBound, playerHorizontalUpperBound);
        pos.y = Mathf.Clamp(pos.y, playerVerticalLowerBound, playerVerticalUpperBound);

        transform.position = pos;
    }
}
