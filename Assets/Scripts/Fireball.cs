using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireForce = 10f;
    public Transform firePoint;
    public float elapsedTime;
    public float fireRate = 2;
    public GameObject fireballPrefab;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > fireRate){
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            elapsedTime = 0;
        }
        
    }

}
