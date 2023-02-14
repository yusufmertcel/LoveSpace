using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "FireBallPoint"){
            Animator animator = GetComponent<Animator>();
            animator.SetBool("isExploded",true);
            Destroy(gameObject,0.3f);
        }
        
    }
}
