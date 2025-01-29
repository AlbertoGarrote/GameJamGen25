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
    public GameObject musicaPulsando;

    private Sprite spriteViejo;
    private GameObject musicaPulsandoInst;
    private bool pulsao;

    public EventHandler<float> BotonPulsado;
    
    void Start()
    {
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
            BotonPulsado?.Invoke(this,0.5f);
        }
        else 
        {
            Destroy(musicaPulsandoInst);
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
            musicaPulsandoInst = Instantiate(musicaPulsando, new Vector3(11f, 0.85f, 0f), Quaternion.identity);
            pulsao = true;
            SoundManager.instance.PlaySound("pulsarBoton", new Vector3(0, 0, 0));
        }
    }
    
}
