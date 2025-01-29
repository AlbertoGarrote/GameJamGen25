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
        SoundManager.instance.PlaySound("abrirPuerta", new Vector3(0, 0, 0));
        puertaAbierta.SetActive(true);
        puertaCerrada.SetActive(false);
    }

    public void CerrarPuerta() 
    {
        SoundManager.instance.PlaySound("cerrarPuerta", new Vector3(0, 0, 0));
        puertaAbierta.SetActive(false);
        puertaCerrada.SetActive(true);
    }

    public void AbrirTrampilla()
    {
        SoundManager.instance.PlaySound("abrirTrampilla", new Vector3(0, 0, 0));
        trampillaAbierta.SetActive(true);
        trampillaCerrada.SetActive(false);
    }

    public void CerrarTrampilla()
    {
        SoundManager.instance.PlaySound("cerrarTrampilla", new Vector3(0, 0, 0));
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
