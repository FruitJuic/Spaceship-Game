using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    public Transform camera;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    Vector2 lookValue = Vector2.zero;

    bool lockedCursor = true;

    public void OnLook(InputValue inputValue)
    {
        lookValue = inputValue.Get<Vector2>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cameraVerticalRotation -= lookValue.y * mouseSensitivity;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        camera.localEulerAngles = Vector3.right * cameraVerticalRotation;

        transform.Rotate(Vector3.up * lookValue.x * mouseSensitivity);
    }
}
