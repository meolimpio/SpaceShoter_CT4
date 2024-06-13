using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGame : MonoBehaviour
{
    // aqui se cria
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoVida;

    void Update()
    {
        this.textoPontuacao.text = (PointsController.Pontuacao + "x");
        this.textoVida.text = (PointsController.Vida + " Vidas");
    }
}
