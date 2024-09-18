using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_block : MonoBehaviour
{
    public GameObject objectToShow;  // El objeto que se mostrará cuando este objeto sea presionado
    private static GameObject lastShownObject;  // Almacena el último objeto que fue mostrado

    private void OnMouseDown()
    {   

        // Si hay un objeto visible actualmente y es diferente al objeto que se quiere mostrar, lo oculta
        if (lastShownObject != null && lastShownObject != objectToShow)
        {
            lastShownObject.SetActive(false);
        }

        // Muestra el nuevo objeto
        objectToShow.SetActive(true);

        // Actualiza el último objeto mostrado
        lastShownObject = objectToShow;
    }
}
