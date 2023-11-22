using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public float jumpAmount = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);


        
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}
