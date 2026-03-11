using UnityEngine;
using UnityEngine.InputSystem;

public class Bola : MonoBehaviour
{
    public float velocidade = 15f;
    private Rigidbody2D rb;
    public bool playing;
    private gameManager gameManagerScript;
    public AudioClip som1; // Referência ao som de colisão
    public AudioClip som2; // Referência ao som de pontuação


    void Start()
    {
        gameManagerScript = GameObject.Find("gameManager").GetComponent<gameManager>();
        rb = GetComponent<Rigidbody2D>();
        LancarBola();
    }

    void LancarBola()
    {
        // Gera uma direção aleatória para esquerda ou direita
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        // Gera uma direção aleatória para cima ou baixo
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.linearVelocity = new Vector2(x, y).normalized * velocidade;
    }

      void OnCollisionEnter2D(Collision2D colisao)
      {

        if (colisao.gameObject.CompareTag("Player"))
        {
            // Calcula a posição relativa da bola em relação à raquete
            float y = (transform.position.y - colisao.transform.position.y) / colisao.collider.bounds.size.y;
            
            Vector2 direcao = new Vector2(rb.linearVelocity.x > 0 ? -1 : 1, y).normalized;
            rb.linearVelocity = direcao * velocidade;
            
        }
        AudioSource.PlayClipAtPoint(som1, transform.position);
      }

      void Update ()
      {
        Keyboard keyboard = Keyboard.current;
        if (keyboard.spaceKey.isPressed && !playing)
        {
            Start();
        }
      }

      void  OnTriggerEnter2D(Collider2D other)
      {
        if (other.gameObject.tag == "R_Wall")
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = Vector3.zero;
            playing = false;
            gameManagerScript.pontuacao1 += 1;
            AudioSource.PlayClipAtPoint(som2, transform.position);
        }

         if (other.gameObject.tag == "L_Wall")
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = Vector3.zero;
            playing = false;
            gameManagerScript.pontuacao2 += 1;
            AudioSource.PlayClipAtPoint(som2, transform.position);
        }
      }
}
