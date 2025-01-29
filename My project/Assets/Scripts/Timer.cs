using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText, timerPuntuacionText;
    private float elapsedTime;
    public int horas, minutos, horasP, minutosP;
    private GameObject martilloInst;
    public GameObject horasResta, martillo, paneltransicion;
    private GameObject horasRestaInst;
    public float tiempoPuntuacion;

    private void Start()
    {
        tiempoPuntuacion = 0;
        //elapsedTime = 420;
        elapsedTime = 1300;
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().BotonPulsado += BotonPulsado;
        GameObject[] listaEventos = GameObject.FindGameObjectsWithTag("evento");

        foreach (GameObject obj in listaEventos)
        {
            obj.GetComponent<GeneralEventos>().Pillado += Pillado;
        }
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        horas = Mathf.FloorToInt(elapsedTime / 60);
        minutos = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", horas, minutos);

        if (horas == 22)
        {
            Time.timeScale = 0f;
            PlayerPrefs.SetFloat("Puntaje", tiempoPuntuacion);
            PlayerPrefs.Save();  
            StartCoroutine("final");
        }

        if (elapsedTime < 420)
        {
            elapsedTime = 420;
        }

        tiempoPuntuacion += Time.deltaTime;
        horasP = Mathf.FloorToInt(tiempoPuntuacion / 60);
        minutosP = Mathf.FloorToInt(tiempoPuntuacion % 60);
        timerPuntuacionText.text = string.Format("{0:00}:{1:00}", horasP, minutosP);
    }

    private void BotonPulsado(object sender, float tiempoModificar)
    {
        elapsedTime += tiempoModificar;
    }
    private void Pillado(object sender, float tiempoModificar)
    {
        StartCoroutine(ModReloj(tiempoModificar));
        
    }

    IEnumerator ModReloj(float tiempoModificar)
    {
        yield return new WaitForSeconds(1f);
        martilloInst = Instantiate(martillo, new Vector3(11f, 0.85f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        SoundManager.instance.PlaySound("GolpeMartillo", new Vector3(0, 0, 0));
        horasRestaInst = Instantiate(horasResta, new Vector3(6.3f, 0.3f, 0f), Quaternion.identity);
        SoundManager.instance.PlaySound("horasRestar", new Vector3(0, 0, 0));
        elapsedTime -= tiempoModificar;
        yield return new WaitForSeconds(1.6f);
        Destroy(martilloInst);
        Destroy(horasRestaInst);
    }

    public int GetHoras() 
    {
        return horas;
    }

    IEnumerator final()
    {
        paneltransicion.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscenaFinal");
    }
}