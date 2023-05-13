using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Criando variáveis
    //Essas são públicas para poder editar visualmente na unity e não só via código
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

    // Update é chamado a cada frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //Vector3 é uma variável que armazena eixos x, y e z
        //No eixo x passamos uma input da unity que detecta quando estamos precionando os botões no eixo horizontal(neste caso)
        // Os 0F aqui são Y e Z que não estão pegando posição por assim dizer
        //Transform position soma a posição + o delta time para deixar a movimentação suave * o speed que é a força da movimentação

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        // Mudando eixos para o personagem se mexer na direção em que vc está andando (a figura)

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
        // Este jump faz parte da imput, por isso está entre aspas
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
