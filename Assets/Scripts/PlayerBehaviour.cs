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

    public GameOver gameOver;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        this.shootingRange = 0;
        this.armaAtual = this.posicoesArmas[0];
        PointsController.Pontuacao = 0;
        PointsController.Vida = 3;
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

        //Exibir a tela de game over
        if(PointsController.Vida == 0){
            Destroy(this.gameObject);
            gameOver.Exibir();
        }

        VerificarLimiteTela();
    }

    private void VerificarLimiteTela()
    {
        Vector2 posicaoAtual = this.transform.position;

        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); //(0, 0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); //(1, 1)

        float pontoReferencialEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferencialDireito = posicaoAtual.x + metadeLargura;

        if(pontoReferencialEsquerdo < limiteInferiorEsquerdo.x) //Saindo pela esquerda
        {
            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);
        }
        else if (pontoReferencialDireito > limiteSuperiorDireito.x) //Saindo pela direita
        {
            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);
        }

        float pontoReferencialSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferencialInferior = posicaoAtual.y - metadeAltura;

        if(pontoReferencialSuperior > limiteSuperiorDireito.y) //Saindo por cima
        {
            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);
        }
        else if(pontoReferencialInferior < limiteInferiorEsquerdo.y) //Saindo por baixo
        {
            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);
        }
    }

    private float Largura
    {
        get{
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }

    private float Altura
    {
        get{
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;
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
            EnemyBehaviour inimigo = outroObjeto.GetComponent<EnemyBehaviour>();
            inimigo.ReceberDano();
        }
    }
}
