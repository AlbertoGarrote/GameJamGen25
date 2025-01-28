using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;
    public int horas, minutos;
    public GameObject martillo;
    private GameObject martilloInst;
    public GameObject horasResta;
    private GameObject horasRestaInst;

    private void Start()
    {
        elapsedTime = 420;
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
            Debug.Log("SE ACABÓ");
        }

        if (elapsedTime < 420)
        {
            elapsedTime = 420;
        }
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
        martilloInst = Instantiate(martillo, new Vector3(11f, 0.85f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        horasRestaInst = Instantiate(horasResta, new Vector3(6.3f, 0.3f, 0f), Quaternion.identity);
        elapsedTime -= tiempoModificar;
        yield return new WaitForSeconds(1.6f);
        Destroy(martilloInst);
        Destroy(horasRestaInst);
    }

    public int GetHoras() 
    {
        return horas;
    }
}