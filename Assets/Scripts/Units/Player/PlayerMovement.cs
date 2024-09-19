using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : PlayerStats
{
    private Vector2 _targetPosition;

    public void MoveCaracter(Vector2 movement)
    {
        if (Input.GetMouseButton(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.fixedDeltaTime * Speed);
        }
    }
}
