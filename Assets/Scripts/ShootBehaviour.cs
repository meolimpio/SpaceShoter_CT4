using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedY;

    void Start()
    {
        this.rb.velocity = new Vector2(0, this.speedY);
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            //Destroi o inimigo
            Destroy(collider.gameObject);
            //Destroi o tiro
            Destroy(this.gameObject);
        }
    }
}
