using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    public GeneralEventos Manager;
    public SpriteManager SpriteManager;
    private bool heDetectado, Sejecutado;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento4Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        SpriteManager.AbrirPuerta();
        Manager.realizarEvento();
        Sejecutado = false;
        SoundManager.instance.PlaySound("Aboss", new Vector3(0, 0, 0));
    }

    private void Update()
    {
        heDetectado = Manager.heDetectado();

        if (Manager.heTerminao() == true) 
        {
            Manager.SetFalse();
            SpriteManager.CerrarPuerta();
        }
        
        if (heDetectado == true && Sejecutado == false)
        {
            Sejecutado = true;
            SoundManager.instance.PlaySound("Pboss", new Vector3(0, 0, 0));
        }
    }
}
