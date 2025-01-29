using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event7 : MonoBehaviour
{
    public GeneralEventos Manager;
    public SpriteManager SpriteManager;
    private bool heDetectado, Sejecutado;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento7Lanzados += HacerAccion;
    }

    private void HacerAccion(object sender, int i)
    {
        SpriteManager.AbrirTrampilla();
        Manager.realizarEvento();
        Sejecutado = false;
        SoundManager.instance.PlaySound("Aminer", new Vector3(0, 0, 0));
    }

    private void Update()
    {
        heDetectado = Manager.heDetectado();

        if (Manager.heTerminao() == true)
        {
            Manager.SetFalse();
            SpriteManager.CerrarTrampilla();
        }

        if (heDetectado == true && Sejecutado == false)
        {
            Sejecutado = true;
            SoundManager.instance.PlaySound("Pminer", new Vector3(0, 0, 0));
        }
    }
}
