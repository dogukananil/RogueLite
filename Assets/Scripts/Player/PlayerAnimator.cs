using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   [SerializeField] private Animator animator;
   private static readonly int Walking = Animator.StringToHash("Walking");

   public void PlayWalkingAnimation(bool walking)
   {
      animator.SetBool(Walking,walking);
   }
}
