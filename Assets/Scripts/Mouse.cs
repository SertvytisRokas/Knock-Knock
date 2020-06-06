using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    float xRotation = 0f;


    // Crosshair
    public RectTransform reticle;

    [Range(50f, 250f)]
    public float defCrosshairSize;
    private float maxCrosshairSize;
    private float maxCrosshairSizeMouse;
    public float speed;
    public float mouseSpeed;
    private float currCrosshairSize;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        maxCrosshairSize = defCrosshairSize * 2f;
        maxCrosshairSizeMouse = defCrosshairSize * 1.5f;
    }

    private void Update()
    {
        // Mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Crosshair
        if (isPlayerMoving || isMouseMoving)
        {
            crosshairMouseAdjustment();
            crosshairMovementAdjustment();
        }
        else
        {
            currCrosshairSize = Mathf.Lerp(currCrosshairSize, defCrosshairSize, Time.deltaTime * speed);
        }
        reticle.sizeDelta = new Vector3(currCrosshairSize, currCrosshairSize);


    }



    void crosshairMouseAdjustment()
    {
        if (isMouseMoving)
        {
            currCrosshairSize = Mathf.Lerp(currCrosshairSize, maxCrosshairSizeMouse, Time.deltaTime * mouseSpeed);
        }
    }

    void crosshairMovementAdjustment()
    {
        if (isPlayerMoving)
        {
            currCrosshairSize = Mathf.Lerp(currCrosshairSize, maxCrosshairSize, Time.deltaTime * speed);
        }
    }

    bool isPlayerMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    bool isMouseMoving
    {
        get
        {
            if (Input.GetAxis("Mouse X") != 0 ||
                Input.GetAxis("Mouse Y") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
