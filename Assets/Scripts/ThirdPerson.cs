using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float smoothTime;
    private CharacterController controler;

    private float velocidadRotacion;

    private Animator anim;
    E
    void Start()
    {
        controler = GetComponent<CharacterController>();

    }

    void Update()
    {
        MoverYRotar();

    }

    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h= -1, h= 1
        float v = Input.GetAxisRaw("Vertical");

        float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);
        Vector2 movimiento = new Vector2(h, v).normalized;

        float angulo = Mathf.Atan2(movimiento.x, movimiento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, anguloSuave, 0);

        if (movimiento.magnitude > 0)
        {
 

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

    }
}
