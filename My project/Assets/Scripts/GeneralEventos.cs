using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralEventos : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spritePillado;
    private Sprite spriteInicial;
    public Animator animator;
    public EventHandler<float> Pillado;
    private bool pillado, ejecutado, terminado;
    
    void Start()
    {
        spriteInicial = spriteRenderer.sprite;
        pillado = false;
        ejecutado = false;
        terminado = false;
    }

    public void realizarEvento()
    {
        terminado = false;
        ejecutado = false;
        StartCoroutine("evento");
    }

    IEnumerator evento() 
    {
        spriteRenderer.sprite = spriteInicial;
        animator.SetBool("accion", true);

        yield return new WaitForSeconds(0.8f);

        pillado = true;
        yield return new WaitForSeconds(2f);
        pillado = false;
        
        animator.SetBool("accion", false);
        yield return new WaitForSeconds(0.5f);
        terminado = true;

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && pillado == true && ejecutado == false)
        {
            spriteRenderer.sprite = spritePillado;
            ejecutado = true;
            Pillado?.Invoke(this, 120f);
            Debug.Log("te he pillao");
        }
        
    }

    public bool heTerminao() 
    {
        return terminado;
    }

    public bool heDetectado()
    {
        return ejecutado;
    }

    public void SetFalse()
    {
        terminado = false;
    }
}
