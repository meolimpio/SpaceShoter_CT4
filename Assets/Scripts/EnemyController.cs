using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyBehaviour originalEnemy;
    private float elapsedTime;
    
    void Start()
    {
        this.elapsedTime = 0;
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

            //Criar um novo inimigo
            Instantiate(this.originalEnemy, enemyPosition, Quaternion.identity);
        }
    }
}
