using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float strafeSpeed;
    [SerializeField]private float jumpForce;
    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody hips;
    public bool isGrounded;
    
    public CinemachineFreeLook freeLookCamera;
    private Transform characterTransform;

    private void Start()
    {
        hips = GetComponent<Rigidbody>();
        characterTransform = transform;
    }

    private void Update()
    {
        // Obtén la dirección de la cámara sin inclinación (horizontal)
        Vector3 cameraForward = freeLookCamera.State.RawOrientation * Vector3.forward;
        cameraForward.y = 0f; // No considerar la inclinación vertical

        // Rota el personaje hacia la dirección de la cámara
        if (cameraForward != Vector3.zero)
        {
            characterTransform.forward = cameraForward.normalized;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("IsRun", true);
                animator.SetBool("IsWalk", false);
                hips.AddForce(hips.transform.forward*speed*1.5f);

            }
            else
            {
                animator.SetBool("IsWalk", true);
                animator.SetBool("IsRun", false);
                hips.AddForce(hips.transform.forward*speed);
            }
        }
        else
        {
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsRun", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsRun", false);
            hips.AddForce(-hips.transform.right*strafeSpeed);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsRun", false);
            hips.AddForce(-hips.transform.forward*speed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsRun", false);
            hips.AddForce(hips.transform.right*strafeSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }

    }
}
