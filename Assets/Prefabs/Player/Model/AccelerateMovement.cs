using System;
using UnityEngine;

public class  AccelerateMovement : IMovementStrategy
{
    private float currentSpeed = 0f;
    private float acceleration = 2f;

    public void Move(Transform transform, Player player)
    {
        currentSpeed += Input.GetAxis("Horizontal") * acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -player.Velocity, player.Velocity);
        transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
    }
}
