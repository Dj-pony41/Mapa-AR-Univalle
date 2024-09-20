using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Imagenes : MonoBehaviour
{
    public GameObject object3D;     // El objeto 3D donde cambiarán los materiales
    public Material[] materials;    // Lista de materiales que se usarán
    public GameObject leftButton;   // Botón 3D izquierdo
    public GameObject rightButton;  // Botón 3D derecho

    private int currentIndex = 0;

    void Start()
    {
        // Mostrar el primer material al iniciar
        if (materials.Length > 0)
        {
            object3D.GetComponent<Renderer>().material = materials[0];
        }
    }

    void Update()
    {
        // Detectar clics en los botones 3D
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == leftButton)
                {
                    ShowPreviousMaterial();
                }
                else if (hit.transform.gameObject == rightButton)
                {
                    ShowNextMaterial();
                }
            }
        }
    }

    // Mostrar el material anterior
    void ShowPreviousMaterial()
    {
        if (materials.Length > 1) // Solo si hay más de un material
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = materials.Length - 1; // Volver al último si es necesario
            }
            object3D.GetComponent<Renderer>().material = materials[currentIndex];
        }
    }

    // Mostrar el siguiente material
    void ShowNextMaterial()
    {
        if (materials.Length > 1) // Solo si hay más de un material
        {
            currentIndex++;
            if (currentIndex >= materials.Length)
            {
                currentIndex = 0; // Volver al primero si es necesario
            }
            object3D.GetComponent<Renderer>().material = materials[currentIndex];
        }
    }
}
