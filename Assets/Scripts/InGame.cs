using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGame : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;

    void Update()
    {
        this.textoPontuacao.text = (PointsController.Pontuacao + "x");
    }
}
