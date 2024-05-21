using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private int life = 100;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;

    private Touch touch;

    [SerializeField] private Transform hitPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask attackMask;

    [SerializeField]private float slideTime;
    private float elapsedTime;

    private bool sliding;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ActionHandler();
        Timer();
        print(elapsedTime);

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void ActionHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startPoint = Input.mousePosition;
        }
        else if (Input.GetButton("Fire1"))
        {
            endPoint = Input.mousePosition;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            direction = endPoint - startPoint;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (endPoint.x - startPoint.x > 0.0f)
                {
                    print("slide");
                    animator.SetBool("slide", true);
                    sliding = true;
                }
                else if (endPoint.x - startPoint.x < 0.0f)
                {
                    print("attack");
                    animator.SetTrigger("attack");
                    AttackArea();
                }
            }
        }
    }

    private void Timer()
    {
        if (sliding == true)
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= slideTime)
        {
            animator.SetBool("slide", false);
            sliding = false;
            elapsedTime = 0;
        }
    }

    private void AttackArea()
    {
        Collider2D[] hittedBlocks = Physics2D.OverlapCircleAll(hitPoint.position, attackRange, attackMask);
        foreach (Collider2D blocks in hittedBlocks)
        {
            if (blocks.CompareTag("IceBlock"))
            {
                Destroy(blocks.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("IceBlock"))
        {
            life -= 10;
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("SkyIce"))
        {
            life -= 10;
        }

    }

    private void OnDrawGizmos()
    {
        if (hitPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, attackRange);
    }
}
