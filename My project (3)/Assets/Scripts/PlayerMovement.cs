using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D;
using Live2D.Cubism.Framework;
using Live2D.Cubism.Core;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CubismModel model;
    [SerializeField] private CubismParameter param;
    private Rigidbody2D rb;
    public float HorizontalMove = 0f;
    public bool FacingRight = true;
    private Animator anim;
    public Vector3 theScale;

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;
    void Start()
    {
        model = this.FindCubismModel();
        param = model.Parameters[1];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        model.Parameters[39 - 1].Value = 0;
    }

    void Update()
    {
        
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if(DialogueManager.Instance.isDialogueActive)
        {
            HorizontalMove = 0;
            return;
        }
        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
        if (HorizontalMove == 0)
        {
            anim.SetBool("Walk", false);
        }
        else if(HorizontalMove > 0 || HorizontalMove < 0)
        {
            anim.SetBool("Walk", true);
        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }

    public void Flip()
    {
        anim.SetBool("Walk", true);
        FacingRight = !FacingRight;
        theScale = transform.localScale;
            theScale.x *= -1;
        transform.localScale = theScale;

        
    }

}
