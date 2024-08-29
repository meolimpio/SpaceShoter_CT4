using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointsController
{
   private static int pontuacao; 
   private static int vida; 
   private static GameOver telaFimJogo;

   public static int Pontuacao
   {
        get
        {
            return pontuacao;
        }

        set
        {
            pontuacao = value;
            if(pontuacao < 0)
            {
                pontuacao = 0;
            }

            // Debug.Log("Pontuação atual para" + Pontuacao);

            if(pontuacao > MelhorPontuacao)
            {
                MelhorPontuacao = pontuacao;
            }
        }
   }
   

   public static int Vida
   {
        get
        {
            return vida;
        }
        
        set
        {
            vida = value;
            if(vida < 0)
            {
                vida = 0;
            }
        }

            // Debug.Log("Vida atual " + vida);
    }

    public static int MelhorPontuacao
    {
        get
        {
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        }

        set
        {
            if(value > MelhorPontuacao)
            {
                PlayerPrefs.SetInt("melhorPontuacao", value);
            }
        }
    }
}