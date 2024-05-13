using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MOVcrontroller : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    private Rigidbody rb;
    private Animator animator;
    private bool isFacingRight = true; // Variable para rastrear la dirección en la que mira el personaje

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento y normalizarlo para mantener una velocidad constante en todas las direcciones
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * moveSpeed;

        // Aplicar el movimiento al Rigidbody del personaje
        rb.velocity = movement;

        // Actualizar la animación
        if (movement.magnitude > 0)
        {
            // Si hay movimiento, activar la animación de caminar
            animator.SetBool("SeMueve", true);

            // Cambiar la dirección del sprite según la entrada de movimiento
            if (moveHorizontal < 0 && isFacingRight)
            {
                Flip();
            }
            else if (moveHorizontal > 0 && !isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            // Si no hay movimiento, activar la animación de estar quieto
            animator.SetBool("SeMueve", false);
        }
    }

    // Método para invertir la escala horizontalmente del objeto del personaje
    void Flip()
    {
        isFacingRight = !isFacingRight; // Cambiar el estado de la dirección del personaje
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invertir la escala en el eje X
        transform.localScale = scale;
    }
}




