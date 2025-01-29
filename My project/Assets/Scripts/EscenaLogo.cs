using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaLogo : MonoBehaviour
{
    public GameObject paneltransicion;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        StartCoroutine("inicio");
    }
    IEnumerator inicio()
    {
        yield return new WaitForSeconds(2.5f);
        paneltransicion.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MenuInicial");
    }
}
