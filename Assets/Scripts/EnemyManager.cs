using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int m_EnemyHealth = 5;
    Rigidbody2D rb;
    //private float knockbackForce = 10.3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        Collider2D collider = other.collider;
        if(other.gameObject.tag == "Bullet"){
            hitDamage(1);
            Debug.Log(m_EnemyHealth);
            if(m_EnemyHealth <= 0){
                Destroy(gameObject);
            }    
        }
        if(other.gameObject.tag == "Player"){
            /*Vector2 direction = (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            rb.AddForce(knockback, ForceMode2D.Impulse);*/
            
            //animator.SetBool("enemyAttack", false);
        }
        
    }

    void hitDamage(int damage){
        m_EnemyHealth -= damage;
    }
}
