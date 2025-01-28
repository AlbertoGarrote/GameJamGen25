using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject puertaAbierta;
    public GameObject puertaCerrada;
    public GameObject trampillaAbierta;
    public GameObject trampillaCerrada;

    private void Start()
    {
        puertaAbierta.SetActive(false);
        puertaCerrada.SetActive(true);
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
}
