using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int m_movSpeed;
    public Transform target;
    public float within_range;
    public float attack_Distance;
    Rigidbody2D rb;

    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(target.position, transform.position);
        
        if(dist <= within_range){
            chase();
        }
        if(dist <= attack_Distance){
            animator.SetBool("enemyAttack", true);
        }
    }

    void chase(){
        Vector2 dir = (target.position - this.transform.position).normalized;
        rb.MovePosition(rb.position + dir * m_movSpeed * Time.fixedDeltaTime);
    }
}
