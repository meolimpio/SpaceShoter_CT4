using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float minSpeed;
    public float maxSpeed;
    private float speedY;
    public int vidas;

    public ParticleSystem particulaExplosaoPrefab;
    
    void Start()
    {
        this.speedY = Random.Range(this.minSpeed, this.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector2(0, -this.speedY);

        Camera camera = Camera.main;
        Vector3 posicaoCamera = camera.WorldToViewportPoint(this.transform.position);

        if(posicaoCamera.y < 0)
        {
            PointsController.Vida--;
            Destroy(this.gameObject);
        }
    }

    public void ReceberDano()
    {
        this.vidas--;
        if(this.vidas <= 0)
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        PointsController.Pontuacao++;
        Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
