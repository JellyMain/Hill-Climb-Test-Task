using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] WheelJoint2D frontWheel;
    [SerializeField] WheelJoint2D backWheel;
    [SerializeField] Rigidbody2D carRB;
    [SerializeField] float wheelMotorSpeed = 500;
    [SerializeField] float wheelMotorForce = 1000;
    [SerializeField] float carTorqueSpeed = 10;
    private bool isMovingForward;
    private bool isMovingBackwards;
    private JointMotor2D frontWheelMotor;
    private JointMotor2D backWheelMotor;



    private void FixedUpdate()
    {
        MoveForward();
        MoveBackwards();
        UpdateMotorState();
    }


    private void UpdateMotorState()
    {
        if (!isMovingBackwards && !isMovingForward)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
        }
        else
        {
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
    }


    private void ApplyMotorSettings(float motorSpeed, float motorForce, float carTorSpeed)
    {
        frontWheelMotor.motorSpeed = motorSpeed;
        backWheelMotor.motorSpeed = motorSpeed;
        frontWheelMotor.maxMotorTorque = motorForce;
        backWheelMotor.maxMotorTorque = motorForce;
        carRB.AddTorque(carTorSpeed * Time.deltaTime);
    }


    private void MoveForward()
    {
        if (isMovingForward)
        {
            ApplyMotorSettings(wheelMotorSpeed, wheelMotorForce, carTorqueSpeed);
        }
        frontWheel.motor = frontWheelMotor;
        backWheel.motor = backWheelMotor;
    }


    private void MoveBackwards()
    {
        if (isMovingBackwards)
        {
            ApplyMotorSettings(-wheelMotorSpeed, wheelMotorForce, -carTorqueSpeed);
        }
        frontWheel.motor = frontWheelMotor;
        backWheel.motor = backWheelMotor;
    }


    public void UpdateForwardBoolean()
    {
        isMovingForward = !isMovingForward;
    }


    public void UpdateBackwardsBoolean()
    {
        isMovingBackwards = !isMovingBackwards;
    }
}
