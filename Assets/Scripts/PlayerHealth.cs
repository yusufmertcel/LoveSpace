using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    private bool keyFound = false;
    public Animator animator; 
    public Transform teleportPoint;
    public PlayerMovement player;
    public GameObject gun;

    bool flag = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "FireBall"){
            TakeDamage(1);
        }
        if(other.gameObject.tag == "Key"){
            Destroy(other.gameObject);
            keyFound = true;
            Debug.Log("You found the key.");
            animator.SetBool("crate_open", keyFound);
        }
        if(other.gameObject.tag == "Exit"){
            if(keyFound){
                Debug.Log("You exited.");
                FindObjectOfType<GameManager>().StopSound("mainmusic");
                FindObjectOfType<GameManager>().PlaySound("ending");
                gameObject.transform.position = teleportPoint.position;
                player.setSpeed(3f);
                gun.SetActive(false);
                //oyun biter.teleport
            }
        }
        if(other.gameObject.tag == "Princess"){
            PlayerManager.gameWon = true;
        }
    }

    public int getHealth(){
        return currentHealth;
    }

    public void TakeDamage(int damage){
        if(currentHealth > 0)
            currentHealth -= damage;
        if(currentHealth == 0){
            if(flag){
                FindObjectOfType<GameManager>().StopSound("mainmusic");
                FindObjectOfType<GameManager>().PlaySound("failed");
                flag = false;
                PlayerManager.gameOver = true; 
            }
            
            GameManager.GameOver();
        }
        healthBar.SetHealth(currentHealth);
    }
}
