using UnityEngine;
using TMPro; 

public class gameManager : MonoBehaviour
{
    public int pontuacao1;
    public int pontuacao2;
    public TMP_Text pontos_player1;
    public TMP_Text pontos_player2;

    void Start()  
{
    pontuacao1= 0;
    pontuacao2= 0;
}
    void Update()  
{
    pontos_player1.text= pontuacao1.ToString();
    pontos_player2.text= pontuacao2.ToString();
}

} 
