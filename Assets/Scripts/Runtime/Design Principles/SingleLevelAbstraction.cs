using UnityEngine;

public class SingleLevelAbstraction : MonoBehaviour
{
    /* single level of abstraction principle (SLAP or SLA) focuses on the readability of code
    by emphasizing that functions should only comprise of statmenet on the same level of "ABSTRACTION"
    
    What is abstraction?
    When you perform a function, it tends to be made of different parts, or sub-actions. */

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

    /* you can kind of imagine an abstraction level as a sort of hierarchy, 
    actions are made of sub-actions and each sub-action is one abstaction level down on the hierarchy.

    Attack() - Level 1 Abstraction
        L CheckHitBox() - Level 2 Abstraction
            L EnableHitBox(), CheckCollisionWithEnemy() - Level 3 Abstraction
    
    as it is right now, this code looks somewhat dense and complicated which can make it hard to read and understand
    it forces us to closely analyse the entire implementation if we want to figure out its function */

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
