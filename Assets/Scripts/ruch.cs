using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Update()
    {
        float moveInput = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moveInput = 1f;
            }
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moveInput = -1f;
            }
        }
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}