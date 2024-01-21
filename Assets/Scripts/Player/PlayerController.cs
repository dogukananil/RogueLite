using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public WeaponController weaponController;
    [SerializeField] private PlayerAnimator playerAnimator;

    private void Update()
    {
        playerMovement.GetInput();
        
        if (playerMovement.IsPlayerMoving())
        {
            playerAnimator.PlayWalkingAnimation(true);
        }
        else
        {
            playerAnimator.PlayWalkingAnimation(false);
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move();
    }
}