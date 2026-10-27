using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 0.15f;

    float xRotation;



    void Update()
    {
        Vector2 look = Vector2.zero;
        look = Mouse.current.delta.ReadValue() * sensitivity;


        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.isPressed)
        {
            var touch = Touchscreen.current.primaryTouch;
            Vector2 pos = touch.position.ReadValue();

            if (pos.x > Screen.width / 2f)
            {
                look = touch.delta.ReadValue() * sensitivity;
            }
        }

        player.Rotate(Vector3.up * look.x);

        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);
    }
}