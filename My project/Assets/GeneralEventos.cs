using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralEventos : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Vector3 targetPosition, posInicial;
    void Start()
    {
        posInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
    }

    public void realizarEvento(object sender, Vector3 Posicion)
    {
        targetPosition = Posicion;
        StartCoroutine("evento");
    }

    IEnumerator evento() 
    {
        this.gameObject.SetActive(true);
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1 * Time.deltaTime);
        }

        yield return null;
    }
}
