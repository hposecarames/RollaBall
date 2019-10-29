using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    private bool dentro = false;
    Animator animator;
    public float proximidad = 4f;

    void Start()
    {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = jugador.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = false;
        }
    }

    void Update()
    {

        if (!dentro)
        {
            enemigo.destination = jugador.position;
        }
        if (dentro)
        {
            enemigo.destination = this.transform.position;
        }

        
       //Comparamos la distancia del enemigo para cambiar el estado del animator, por defecto es "Tranquilo"
        if (!enemigo.pathPending && (enemigo.remainingDistance < proximidad))
        {
            //Si la distancia es menor de 4f se activa el estado y la animación de peligro
            Debug.Log("Peligro");
            animator.SetBool("Peligro", true);
            
        }
        else
        {
            //Si la distancia es mayor de 4f se desactiva peligro y se activa la animación "Tranquilo"
            Debug.Log("Tranquilo");
            animator.SetBool("Peligro", false);
            


        }
    }
}
