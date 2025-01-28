using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite nuevoSprite;
    private Sprite spriteViejo;
    public GameObject brazo;

    public EventHandler<float> BotonPulsado;
    
    void Start()
    {
        brazo.SetActive(false);
        spriteViejo = spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            brazo.SetActive(true);
            animator.SetBool("pulsado", true);
            spriteRenderer.sprite = nuevoSprite;
            BotonPulsado?.Invoke(this,0.5f);
        }
        else 
        {
            brazo.SetActive(false);
            animator.SetBool("pulsado", false);
            spriteRenderer.sprite = spriteViejo;
        }
    }

    
}
