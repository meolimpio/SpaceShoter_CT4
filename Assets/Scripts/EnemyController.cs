using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyBehaviour inimigo1;
    public EnemyBehaviour inimigo2;
    private float elapsedTime;
    
    void Start()
    {
        this.elapsedTime = 0;
        TurnOn();
    }
    public void TurnOff()
    {
    this.enabled = false;
    }
    public void TurnOn()
    {
    this.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        this.elapsedTime += Time.deltaTime;

        if(this.elapsedTime >= 1f)
        {
            this.elapsedTime = 0;

            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            
            float xPosition = Random.Range(minPosition.x, maxPosition.x);
            Vector2 enemyPosition = new Vector2(xPosition, maxPosition.y);

            EnemyBehaviour prefabInimigo;

            float chance = Random.Range(0f, 100f);

            //20% de chance de spawnar o segundo inimigo
            if(chance <=20)
            {
                prefabInimigo = this.inimigo2;
            }
            else
            {
                prefabInimigo = this.inimigo1;
            }

            //Criar um novo inimigo
            Instantiate(prefabInimigo, enemyPosition, Quaternion.identity);
        }
    }
}
