using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void RecibirDanho(float danhoRecibido)
    {

        mainScript.Vidas -= (danhoRecibido * multiplicadorDanho);
        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }
    }

    public void Explotar(float fuerzaExplosion, Vector3 puntoImpacto, float radioExplosion, float upModifier)
    {
        mainScript.Morir();
        rb.AddExplosionForce(fuerzaExplosion, transform.position, upModifier);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
