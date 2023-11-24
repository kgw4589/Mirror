using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private PlayerInputHandler input;

    public Transform orientation;
    public Transform camHolder;

    public float xSensitivity;
    public float ySensitivity;
    public bool cursorLocked = true;
    float xRotation;
    float yRotation;
    private void Awake()
    {
        TryGetComponent(out input);
    }

    private void LateUpdate()
    {
        PlayerCamMovement();
    }
    private void PlayerCamMovement()
    {
        float x = input.look.x * Time.deltaTime * xSensitivity;
        float y = input.look.y * Time.deltaTime * ySensitivity;

        yRotation += x;
        xRotation += y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camHolder.localRotation = Quaternion.Euler(xRotation, 0, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
