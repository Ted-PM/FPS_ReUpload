using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public Transform playerCamera;

    private CharacterController characterController;
    private float verticalRotation = 0;
    private float verticalVelocity = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Mouse Look
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float moveForward = Input.GetAxis("Vertical") * moveSpeed;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveSideways, verticalVelocity, moveForward);
        movement = transform.rotation * movement;

        // Jumping
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= Time.deltaTime * 10.0f; // Apply gravity
        }

        characterController.Move(movement * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");

        if (collision.gameObject.GetComponent<Zombie>())
        {
            GameManager.Instance.GameOver();
        }
        //else if (collision.gameObject.GetComponent<Amo>())
        //{
        //    Debug.Log("Amo collision");
        //    gameObject.GetComponent<Cannon>().ReFillAmo();
        //    Destroy(collision.gameObject.GetComponent<Amo>());
        //}
    }
}