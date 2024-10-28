using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float movimientoVertical;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;
    
    private CharacterController controller;


    private Vector3 movimientoVertical;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        MoverYRotar();

    }
    
    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h= -1, h= 1
        float v = Input.GetAxisRaw("Vertical");

        Vector2 movimiento = new Vector2(h,v).normalized;
        if(h!=0 || v!=0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            controller.Move(movimiento * velocidad * Time.deltaTime);
        }
        
        if(movimiento.magnitude > 0)
        {
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        
    }

    private void EnSuelo()
    {
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }
}
