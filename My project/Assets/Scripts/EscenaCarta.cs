using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCarta : MonoBehaviour
{
    public GameObject paneltransicion;
    
    void Start()
    {
        SoundManager.instance.PlaySound("musicaTension", new Vector3(0, 0, 0));
        SoundManager.instance.PlaySound("papel", new Vector3(0, 0, 0));
    }

    public void siguienteEscena()
    {
        StartCoroutine("siguiente");
    }

    IEnumerator siguiente()
    {
        SoundManager.instance.PlaySound("firma", new Vector3(0, 0, 0));
        paneltransicion.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EscenaPrincipal");
    }
}
