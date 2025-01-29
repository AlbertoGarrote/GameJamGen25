using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public Animator animatorPausa;
    public GameObject transicionPanel;

    private void Start()
    {
        menuPausa.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
        }
        
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        StartCoroutine("despausar");       
    }

    public void SalirJuegoPausa()
    {
        Time.timeScale = 1f;
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
        
    }
}

