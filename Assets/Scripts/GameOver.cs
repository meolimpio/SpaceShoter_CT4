using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoMelhorPontuacao;
    
    public EnemyController enemyController;
    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (PointsController.Pontuacao + "x");
        this.textoMelhorPontuacao.text = (PointsController.MelhorPontuacao.ToString());
        enemyController.TurnOff();
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
        enemyController.TurnOn();
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase01");
    }
}
