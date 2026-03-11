using UnityEngine;
using UnityEngine.InputSystem;

public class Barra_Esquerda : MonoBehaviour
{

     public Vector3 minhaPosicao;
     public float meuY;
     public float velocidade = 5f;
     public float meuLimite = 3.0f;


     void Start()
     {
          minhaPosicao = transform.position;
     }
      void Update()
    {
        float deltaVelocidade = velocidade * Time.deltaTime;
        minhaPosicao.y = meuY;
        transform.position = minhaPosicao;
        Keyboard teclado = Keyboard.current;

        if(Keyboard.current.aKey.isPressed)
        {
            meuY = meuY + deltaVelocidade;
        }

        if(Keyboard.current.dKey.isPressed)
        {
           meuY = meuY - deltaVelocidade;
        }

        // Verifica se a raquete está tentando passar do limite inferior da tela
        if (meuY < -meuLimite)
        {
            // Se sim, fixa a posição no limite inferior
            meuY = -meuLimite;
        }

        // Verifica se a raquete está tentando passar do limite superior da tela
        if (meuY > meuLimite)
        {
            // Se sim, fixa a posição no limite superior
            meuY = meuLimite;
        }
    }
}