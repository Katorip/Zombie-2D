using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform target;   
    [SerializeField] float speed = 3f;
    
    private Vector2 targetPos;
    private Vector2 localMousePosition;
    private Vector2 mousePos2D;
    private Animator animator;

    void Start()
    {
        targetPos = transform.position;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (animator)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Where player clicks
                targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                localMousePosition = (Vector2)transform.InverseTransformPoint(targetPos);
                mousePos2D = new Vector2(targetPos.x, targetPos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                // If player hits collider
                if (hit.collider != null)
                {
                    return;
                }
                else
                {
                    // Move the target to that position
                    target.position = targetPos;
                }
            }

            // Move the player
            if ((Vector2)transform.position != targetPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                animator.SetBool("IsMoving", true);
                animator.SetFloat("PosX", localMousePosition.x);
                animator.SetFloat("PosY", localMousePosition.y);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
