using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public Animator animatorPausa;
    public GameObject transicionPanel;
    private bool puedePausarse;

    private void Start()
    {
        puedePausarse = true;
        menuPausa.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && puedePausarse == true)
        {
            SoundManager.instance.PlaySound("papel", new Vector3(0, 0, 0));
            puedePausarse = false;
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
        }
        
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        SoundManager.instance.PlaySound("firma", new Vector3(0, 0, 0));
        StartCoroutine("despausar");       
    }

    public void SalirJuegoPausa()
    {
        Time.timeScale = 1f;
        SoundManager.instance.PlaySound("firma", new Vector3(0, 0, 0));
        StartCoroutine("volverMenu");
    }

    IEnumerator volverMenu()
    {
        transicionPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MenuInicial");
    }

    IEnumerator despausar()
    {
        animatorPausa.SetBool("accion", true);
        yield return new WaitForSeconds(0.5f);
        menuPausa.SetActive(false);
        puedePausarse = true;

    }
}

