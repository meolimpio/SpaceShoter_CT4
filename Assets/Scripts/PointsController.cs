using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointsController
{
   private static int pontuacao; 
   private static int vida; 

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
        }
   }

   // aqui e paga
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

            // Debug.Log("Vida atual " + vida);
        }
   }
}
