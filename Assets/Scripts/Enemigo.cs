using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    [Header("Sistema combate")]
    [SerializeField] private float danhoEnemigo;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    private NavMeshAgent agent;
    private Animator anim;

    private Personaje player;
    private bool ventanaAbierta;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Personaje>();
    }

    private void Update()
    {
        Perseguir();
        if(ventanaAbierta)
        {
            DetectarImpacto();
        }
    }

    private void DetectarImpacto()
    {
        Physics.OverlapSphere(attackPoint, radioAtaque, queEsDanhable);
        if(collsDetectados.Length > 0)
        {
            for(int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<Personaje>().RecibirDanho(danhoEnemigo);
            }
        }
    }
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
    }

    private void FinAtaque()
    {
        agent.isStopped = false;
        anim.SetBool("attacking", false);
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
}
