using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviarCanvases : MonoBehaviour
{
    public Canvas c;

    public void Canvases()
    {
        Debug.Log("Instrucciones");
        c.sortingOrder = 1;
    }
}
