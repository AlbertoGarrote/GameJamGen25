using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject HStext;
    public int horasP, minutosP;
    public GameObject paneltransicion, botonVolver;
    private float puntaje, puntaje1, puntaje2, puntaje3, puntaje4, puntaje5;
    private bool highscore, metido;
    
    void Start()
    {
        botonVolver.SetActive(false);
        HStext.SetActive(false);

        puntaje = PlayerPrefs.GetFloat("Puntaje", 1320);
        puntaje1 = PlayerPrefs.GetFloat("Puntaje1", 1320);
        puntaje2= PlayerPrefs.GetFloat("Puntaje2", 1320);
        puntaje3 = PlayerPrefs.GetFloat("Puntaje3", 1320);
        puntaje4 = PlayerPrefs.GetFloat("Puntaje4", 1320);
        puntaje5 = PlayerPrefs.GetFloat("Puntaje5", 1320);

        horasP = Mathf.FloorToInt(puntaje / 60);
        minutosP = Mathf.FloorToInt(puntaje % 60);
        timerText.text = string.Format("{0:00}:{1:00}", horasP, minutosP);
        highscore = false;
        metido = false;
        
        calcularHighScore();

        SoundManager.instance.PlaySound("musicaFinal", new Vector3(0, 0, 0));
        SoundManager.instance.PlaySound("reloj", new Vector3(0, 0, 0));

        StartCoroutine("final");
    }

    IEnumerator final()
    {
        yield return new WaitForSeconds(2f);
        botonVolver.SetActive(true);
        if(highscore)
        {
            HStext.SetActive(true);
            SoundManager.instance.PlaySound("HS", new Vector3(0, 0, 0));
        }
    }


    public void siguienteEscena()
    {
        StartCoroutine("siguiente");
    }

    IEnumerator siguiente()
    {
        SoundManager.instance.PlaySound("boton", new Vector3(0, 0, 0));
        paneltransicion.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuInicial");
    }


    public void calcularHighScore()
    {
        if (puntaje <= puntaje1 && metido == false)
        {
            PlayerPrefs.SetFloat("Puntaje1", puntaje);
            PlayerPrefs.SetFloat("Puntaje2", puntaje1);
            PlayerPrefs.SetFloat("Puntaje3", puntaje2);
            PlayerPrefs.SetFloat("Puntaje4", puntaje3);
            PlayerPrefs.SetFloat("Puntaje5", puntaje4);
            metido = true;
            highscore = true;
        }
        else if (puntaje <= puntaje2 && metido == false)
        {
            PlayerPrefs.SetFloat("Puntaje2", puntaje);
            PlayerPrefs.SetFloat("Puntaje3", puntaje2);
            PlayerPrefs.SetFloat("Puntaje4", puntaje3);
            PlayerPrefs.SetFloat("Puntaje5", puntaje4);
            metido = true;
        }
        else if (puntaje <= puntaje3 && metido == false)
        {
            PlayerPrefs.SetFloat("Puntaje3", puntaje);
            PlayerPrefs.SetFloat("Puntaje4", puntaje3);
            PlayerPrefs.SetFloat("Puntaje5", puntaje4);
            metido = true;
        }
        else if (puntaje <= puntaje4 && metido == false)
        {
            PlayerPrefs.SetFloat("Puntaje4", puntaje);
            PlayerPrefs.SetFloat("Puntaje5", puntaje4);
            metido = true;
        }
        else if (puntaje <= puntaje5 && metido == false)
        {
            PlayerPrefs.SetFloat("Puntaje5", puntaje);
            metido = true;
        }
        PlayerPrefs.Save();
    }
}
