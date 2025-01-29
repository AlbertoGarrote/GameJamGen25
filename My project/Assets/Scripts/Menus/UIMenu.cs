using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pText1, pText2, pText3, pText4, pText5;

    public GameObject menuOpciones;
    public GameObject menuPrincipal;
    public GameObject transicionPanel;

    private float puntaje1, puntaje2, puntaje3, puntaje4, puntaje5;
    private int horas1, minutos1, horas2, minutos2, horas3, minutos3, horas4, minutos4, horas5, minutos5;

    private void Start()
    {
        SoundManager.instance.PlaySound("musicaMenu", new Vector3(0, 0, 0));

        puntaje1 = PlayerPrefs.GetFloat("Puntaje1", 1320);
        puntaje2 = PlayerPrefs.GetFloat("Puntaje2", 1320);
        puntaje3 = PlayerPrefs.GetFloat("Puntaje3", 1320);
        puntaje4 = PlayerPrefs.GetFloat("Puntaje4", 1320);
        puntaje5 = PlayerPrefs.GetFloat("Puntaje5", 1320);

        horas1 = Mathf.FloorToInt(puntaje1 / 60);
        minutos1 = Mathf.FloorToInt(puntaje1 % 60);
        pText1.text = string.Format("{0:00}:{1:00}", horas1, minutos1);

        horas2 = Mathf.FloorToInt(puntaje2 / 60);
        minutos2 = Mathf.FloorToInt(puntaje2 % 60);
        pText2.text = string.Format("{0:00}:{1:00}", horas2, minutos2);

        horas3 = Mathf.FloorToInt(puntaje3 / 60);
        minutos3 = Mathf.FloorToInt(puntaje3 % 60);
        pText3.text = string.Format("{0:00}:{1:00}", horas3, minutos3);

        horas4 = Mathf.FloorToInt(puntaje4 / 60);
        minutos4 = Mathf.FloorToInt(puntaje4 % 60);
        pText4.text = string.Format("{0:00}:{1:00}", horas4, minutos4);

        horas5 = Mathf.FloorToInt(puntaje5 / 60);
        minutos5 = Mathf.FloorToInt(puntaje5 % 60);
        pText5.text = string.Format("{0:00}:{1:00}", horas5, minutos5);
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
        SceneManager.LoadScene("EscenaCarta");
    }
}


