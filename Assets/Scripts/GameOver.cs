using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    
    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (PointsController.Pontuacao + "x");
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase01");
    }
}
