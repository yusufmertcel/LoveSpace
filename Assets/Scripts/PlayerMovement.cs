using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_movSpeed = 5f;
    //public Animator animator;

    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void setSpeed(float speed){
        m_movSpeed = speed;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * m_movSpeed * Time.fixedDeltaTime);
        
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            //Teleport();
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Teleport(){
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        Vector2 shiftPoint = lookDir/lookDir.normalized;
        Debug.Log(angle);
        gameObject.transform.position = shiftPoint;

    }
}
