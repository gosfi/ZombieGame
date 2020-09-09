using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTest : MonoBehaviour
{
    public GameObject reviveText;
    Color oldColor = Color.white;

    bool canRevive = false;
    float reviveTime = 0f;

    private void OnTriggerEnter(Collider other)
    {



        reviveText.SetActive(true);
        canRevive = true;

      


        Renderer render = GetComponent<Renderer>();

        oldColor = render.material.color;
        render.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {


        reviveText.SetActive(false);
        canRevive = false;
        



        Renderer render = GetComponent<Renderer>();
        render.material.color = oldColor;
    }

    private void Update()
    {
        Debug.Log("Revive time : " + reviveTime);
        if (Input.GetKey(KeyCode.F) && canRevive)
        {
            reviveTime += 2 * Time.deltaTime;

            
        }
        else
        {
            reviveTime -= Time.deltaTime;
            
        }

        if(reviveTime <= 0)
        {
            reviveTime = 0;
        }

        if (reviveTime >= 10f)
        {
            canRevive = false;
            reviveTime = 0f;

            Debug.Log("Player has revived!");
        }
    }
}
