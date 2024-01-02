using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed;
    private float mouseX, mouseY;
    public float torsoOffSet;
    public ConfigurableJoint hipJoint, torsoJoint;

    public CinemachineFreeLook freeLookCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Obtén la referencia a la cámara FreeLook de Cinemachine
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        CamControl();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed; // Resta aquí para invertir el movimiento del mouse
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);

        // Aplica las rotaciones directamente a la cámara FreeLook
        freeLookCamera.m_XAxis.Value = mouseX;
        freeLookCamera.m_YAxis.Value = mouseY;

        hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
        torsoJoint.targetRotation = Quaternion.Euler(-mouseY + torsoOffSet, 0, 0);
    }
}
