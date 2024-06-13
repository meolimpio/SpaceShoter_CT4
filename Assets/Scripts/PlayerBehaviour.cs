using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed;
    public ShootBehaviour shotPrefab;
    public float shotWaitingTime;

    private float shootingRange;
    public Transform[] posicoesArmas;
    private Transform armaAtual;
    
    void Start()
    {
        this.shootingRange = 0;
        this.armaAtual = this.posicoesArmas[0];
        PointsController.Pontuacao = 0;
        PointsController.Vida = 5;
    }

    // Update is called once per frame
    void Update()
    {
        this.shootingRange += Time.deltaTime;
        if (this.shootingRange >= this.shotWaitingTime)
        {
            this.shootingRange = 0;
            //Atira
            Atirar();
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float speedX = (horizontal * this.movementSpeed);
        float speedY = (vertical * this.movementSpeed);

        this.rb.velocity = new Vector2(speedX, speedY);
        //Aqui ce muda
        if(PointsController.Vida == 0){
            Destroy(this);
        }
    }

    private void Atirar()
    {
        Instantiate(this.shotPrefab, this.armaAtual.position, Quaternion.identity);
        if(this.armaAtual == this.posicoesArmas[0])
        {
            this.armaAtual = this.posicoesArmas[1];
        }
        else
        {
            this.armaAtual = this.posicoesArmas[0];
        }
    }
    //aqui se faz
    public void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if(outroObjeto.CompareTag("Enemy")){
            
            PointsController.Vida--;
            Destroy(outroObjeto.gameObject);
        }
    }
}
