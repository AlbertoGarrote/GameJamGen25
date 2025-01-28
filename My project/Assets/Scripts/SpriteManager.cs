using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject puertaAbierta;
    public GameObject puertaCerrada;
    public GameObject trampillaAbierta;
    public GameObject trampillaCerrada;
    public GameObject reloj;
    public GameObject relojpulsado;

    private void Start()
    {
        puertaAbierta.SetActive(false);
        puertaCerrada.SetActive(true);
        trampillaAbierta.SetActive(false);
        trampillaCerrada.SetActive(true);
        reloj.SetActive(true);
        relojpulsado.SetActive(false);


    }
    public void AbrirPuerta() 
    {
        puertaAbierta.SetActive(true);
        puertaCerrada.SetActive(false);
    }

    public void CerrarPuerta() 
    {
        puertaAbierta.SetActive(false);
        puertaCerrada.SetActive(true);
    }

    public void AbrirTrampilla()
    {
        trampillaAbierta.SetActive(true);
        trampillaCerrada.SetActive(false);
    }

    public void CerrarTrampilla()
    {
        trampillaAbierta.SetActive(false);
        trampillaCerrada.SetActive(true);
    }

    public void RelojNormal()
    {
        reloj.SetActive(true);
        relojpulsado.SetActive(false);
    }

    public void RelojPulsado()
    {
        reloj.SetActive(false);
        relojpulsado.SetActive(true);
    }
}
