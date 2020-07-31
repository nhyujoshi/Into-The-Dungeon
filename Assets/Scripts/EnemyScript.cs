using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //[SerializeField] private LayerMask groundLayerMask;

    private bool SearchingForThePlayer = false;

    private Transform Player;

    private BoxCollider2D boxCollider2d;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //StartCoroutine(GetPlayer());
    }

    void Update()
    {
        //distance to player
        float disToPlayer = Vector2.Distance(transform.position, Player.position);

        if(disToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < Player.position.x)
        {
            //enemy is to the left of the player so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else /*if(transform.position.x > player.position.x)*/
        {
            //enemy is to the right of player so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        if (Player == null)
        {
            if (!SearchingForThePlayer)
            {
                SearchingForThePlayer = true;
                StartCoroutine(FindingThePlayer());

            }
            return;
        }
    }

    IEnumerator FindingThePlayer()
    {
        GameObject Result = GameObject.FindGameObjectWithTag("Player");
        if (Result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FindingThePlayer());
        }
        else
        {
            Player = Result.transform;
            SearchingForThePlayer = false;
            FixedUpdate();
            yield return null;
        }
    }

    //private bool IsGrounded()
    //{
    //    float extraHeightText = 1f;

    //    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
    //    return raycastHit.collider != null;
    //}
}
