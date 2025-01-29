using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuPrincipal;
    public GameObject transicionPanel;

    private void Start()
    {
        SoundManager.instance.PlaySound("musicaMenu", new Vector3(0, 0, 0));
    }

    public void Jugar()
    {
        StartCoroutine("jugar");
    }
    public void OptionsPanel()
    {
        menuOpciones.SetActive(true);
        menuPrincipal.SetActive(false);

    }
    public void OptionsPanelVolver()
    {
        menuOpciones.SetActive(false);
        menuPrincipal.SetActive(true);
    }


    public void SalirJuego()
    {
        Application.Quit();
        print("Saliste del videojuego");
    }

    IEnumerator jugar()
    {
        transicionPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EscenaPrincipal");
    }
}


