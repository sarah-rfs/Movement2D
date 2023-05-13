using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    Character Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Character>();
    }

    // Criando dois métodos padrões da Unity , estes servem para verificar quando se está tocando um objeto e quando se está parando de tocar este objeto

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Player.isJumping = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Player.isJumping = true;
        }

    }
}
