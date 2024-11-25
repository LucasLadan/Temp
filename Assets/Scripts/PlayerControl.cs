using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float speed;
    [SerializeField] private float cameraSpeed;
    private Camera _camera;
    private float xRotation;
    [SerializeField] private float cameraBounds= 60f;
    [SerializeField] private float timeLeft;
    [SerializeField] private TextMeshProUGUI timeLeft1;

    #region Smoothing
    private Vector3 _movement;
    private Vector2 currentMouseDelta;
    private Vector2 mouseVelocity;
    [SerializeField] private float mouseSmooth;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            Movement();
            cameraMovement();
            timeLeft -= Time.deltaTime;
            timeLeft1.text = ("Timer: " + ((int) timeLeft));
        }
        
        
        

    }

    public void cameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed;

        Vector2 targetDelta = new Vector2(mouseX, mouseY);
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetDelta, ref mouseVelocity, mouseSmooth);

        xRotation -= currentMouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -cameraBounds, cameraBounds);

        transform.Rotate(Vector3.up * currentMouseDelta.x);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        _movement = transform.right * moveX + transform.forward * moveZ;
        _movement.Normalize();
        _controller.SimpleMove(_movement);
    }

    public void AddTime(int addedTime)
    {
        timeLeft += addedTime;
    }
}
