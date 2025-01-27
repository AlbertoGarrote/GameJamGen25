using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite nuevoSprite;
    public Sprite spriteViejo;

    public EventHandler<float> BotonPulsado;
    
    void Start()
    {
        spriteViejo = spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("pulsado", true);
            spriteRenderer.sprite = nuevoSprite;
            BotonPulsado?.Invoke(this,0.5f);
        }
        else 
        {
            animator.SetBool("pulsado", false);
            spriteRenderer.sprite = spriteViejo;
        }
    }

    
}
