using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixing : MonoBehaviour
{

    public Text repairText;
    public Image repairBar;
    public Image filling;
    private float repair;
    private float maxrepair;
    bool inEvent;

    void Start()
    {
        repair = 0f;
        maxrepair = 100f;
        filling.gameObject.SetActive(false);
        repairText.gameObject.SetActive(false);
        repairBar.gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && inEvent == true && repair < 101)
        {
            Debug.Log("HIII");
            filling.fillAmount = repair / maxrepair;
            repair += 1;
        }
        if (inEvent == true && !(Input.GetButton("Fire1")))
        {
            if (repair < 100)
            {
                repair = 0;
                filling.fillAmount = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "repair")
        {
            inEvent = true;
            repairText.gameObject.SetActive(true);
            repairBar.gameObject.SetActive(true);
            filling.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        inEvent = false;
        repairText.gameObject.SetActive(false);
        repairBar.gameObject.SetActive(false);
    }

    void fill()
    {
        Debug.Log("HIII");
    }

    void reset()
    {
        if (repair != 101)
        {
            repair = 0;
        }
    }
}
