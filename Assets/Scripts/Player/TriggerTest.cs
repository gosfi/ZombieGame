using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTest : MonoBehaviour
{
    Color oldColor = Color.white;
    


    public PlayerSettings player;

    private void OnTriggerEnter(Collider other)
    {
        player.reviveText.SetActive(true);
        player.canRevive = true;

        Renderer render = GetComponent<Renderer>();

        oldColor = render.material.color;
        render.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        player.reviveText.SetActive(false);
        player.canRevive = false;

        Renderer render = GetComponent<Renderer>();
        render.material.color = oldColor;
    }
}
