using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float minSpeed;
    public float maxSpeed;
    private float speedY;
    
    void Start()
    {
        this.speedY = Random.Range(this.minSpeed, this.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector2(0, -this.speedY);
    }

    public void Destruir()
    {
        PointsController.Pontuacao++;
        Destroy(this.gameObject);
    }
}
