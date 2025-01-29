using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite nuevoSprite;
    public GameObject brazo;
    public SpriteManager spriteManager;

    private Sprite spriteViejo;
    private bool pulsao;

    public EventHandler<float> BotonPulsado;
    
    void Start()
    {
        SoundManager.instance.PlaySound("ambiente", new Vector3(0, 0, 0));
        SoundManager.instance.PlaySound("musicaFondo", new Vector3(0, 0, 0));
        pulsao = false;
        brazo.SetActive(false);
        spriteViejo = spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pulsarBoton();
            spriteManager.RelojPulsado();
            brazo.SetActive(true);
            animator.SetBool("pulsado", true);
            spriteRenderer.sprite = nuevoSprite;
            BotonPulsado?.Invoke(this,0.4f);
        }
        else 
        {
            pulsao = false;
            spriteManager.RelojNormal();
            brazo.SetActive(false);
            animator.SetBool("pulsado", false);
            spriteRenderer.sprite = spriteViejo;
        }
    }

    public void pulsarBoton()
    {
        if (pulsao == false)
        {
            pulsao = true;
            SoundManager.instance.PlaySound("pulsarBoton", new Vector3(0, 0, 0));
        }
    }
    
}
