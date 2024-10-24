using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        MoverYRotar();

    }
    
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h= -1, h= 1
        float v = Input.GetAxisRaw("Vertical");

        Vector2 movimiento = new Vector2(h,v).normalized;

        float anguloRotacion = Mathf.Atan2(movimiento.x,movimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        
        if(movimiento.magnitude > 0)
        {
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        
    }
}
