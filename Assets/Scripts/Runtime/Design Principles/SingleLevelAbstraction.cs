using System;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;

public class SingleLevelAbstraction : MonoBehaviour
{
    /*single level of abstraction principle (SLAP or SLA) focuses on the readability of code
    by emphasizing that functions should only comprise of statmenet on the same level of "ABSTRACTION"
    
    What is abstraction?
    When you perform a function, it tends to be made of different parts, or sub-actions.*/

    public Rigidbody2D rb;
    public Animator playerAnimator;
    public AudioClip jumpAudioClip;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector2.down, 1);
            if (ray.collider != null)
            {
                rb.AddForceY(1, ForceMode2D.Impulse);
                AudioSource.PlayClipAtPoint(jumpAudioClip, rb.position);
                playerAnimator.SetTrigger("Jump");
            }
        }
    }

    /*you can kind of imagine an abstraction level as a sort of hierarchy, imagine if you had an attack script,
    the chain of abstractions could be Attack(), which would then feed into EnableHitbox() then CheckIfEnemyHit() then DamageEnemy().
    those are your levels of abstraction.
    
    as it is right now, this code looks somewhat dense and complicated which can make it hard to read and understand
    it forces us to closely analyse the entire implementation if we want to figure out its function*/

    public void UpdateRefactored()
    {
        if (IsJumpPressed())
        {
            OnJumpPressed();
        }
    }

    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void OnJumpPressed()
    {
        if (IsPlayerGrounded())
        {
            ExecuteJump();
            PlayJumpAnimation();
            PlayJumpAudio();
        }
    }

    public bool IsPlayerGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.position, Vector2.down, 1);
        return ray.collider != null;
    }

    public void ExecuteJump()
    {
        rb.AddForceY(1, ForceMode2D.Impulse);
    }

    public void PlayJumpAudio()
    {
        AudioSource.PlayClipAtPoint(jumpAudioClip, rb.position);
    }

    public void PlayJumpAnimation()
    {
        playerAnimator.SetTrigger("Jump");
    }
}
