using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Criando vari�veis
    //Essas s�o p�blicas para poder editar visualmente na unity e n�o s� via c�digo
    public float Speed;
    public float JumpForce;

    public bool isJumping;

    // Private 
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update � chamado a cada frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //Vector3 � uma vari�vel que armazena eixos x, y e z
        //No eixo x passamos uma input da unity que detecta quando estamos precionando os bot�es no eixo horizontal(neste caso)
        // Os 0F aqui s�o Y e Z que n�o est�o pegando posi��o por assim dizer
        //Transform position soma a posi��o + o delta time para deixar a movimenta��o suave * o speed que � a for�a da movimenta��o

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        // Mudando eixos para o personagem se mexer na dire��o em que vc est� andando (a figura)

        float inputAxis = Input.GetAxis("Horizontal");

        if(inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void Jump()
    {
        // Este jump faz parte da imput, por isso est� entre aspas
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
