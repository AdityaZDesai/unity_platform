using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
