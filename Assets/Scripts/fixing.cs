using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixing : MonoBehaviour
{

    public Text repairText1;
    public Image repairBar1;
    public Image filling1;
    public Text repairText2;
    public Image repairBar2;
    public Image filling2;
    public Text repairText3;
    public Image repairBar3;
    public Image filling3;
    private float repair;
    private float maxrepair;
    bool inEvent1;
    bool inEvent2;
    bool inEvent3;

    void Start()
    {
        repair = 0f;
        maxrepair = 100f;
        filling1.gameObject.SetActive(false);
        repairText1.gameObject.SetActive(false);
        repairBar1.gameObject.SetActive(false);
        filling2.gameObject.SetActive(false);
        repairText2.gameObject.SetActive(false);
        repairBar2.gameObject.SetActive(false);
        filling3.gameObject.SetActive(false);
        repairText3.gameObject.SetActive(false);
        repairBar3.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && inEvent1 == true && repair < 101)
        {
            filling1.fillAmount = repair / maxrepair;
            repair += 1;
        }
        if (inEvent1 == true && !(Input.GetButton("Fire1")))
        {
            if (repair < 100)
            {
                repair = 0;
                filling1.fillAmount = 0;
            }
        }
        if (Input.GetButton("Fire1") && inEvent2 == true && repair < 101)
        {
            filling2.fillAmount = repair / maxrepair;
            repair += 1;
        }
        if (inEvent2 == true && !(Input.GetButton("Fire1")))
        {
            if (repair < 100)
            {
                repair = 0;
                filling2.fillAmount = 0;
            }
        }
        if (Input.GetButton("Fire1") && inEvent == true && repair < 101)
        {
            filling3.fillAmount = repair / maxrepair;
            repair += 1;
        }
        if (inEvent == true && !(Input.GetButton("Fire1")))
        {
            if (repair < 100)
            {
                repair = 0;
                filling3.fillAmount = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "repair1")
        {
            inEvent = true;
            repairText1.gameObject.SetActive(true);
            repairBar1.gameObject.SetActive(true);
            filling1.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "repair2")
        {
            inEvent = true;
            repairText2.gameObject.SetActive(true);
            repairBar2.gameObject.SetActive(true);
            filling2.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "repair3")
        {
            inEvent = true;
            repairText3.gameObject.SetActive(true);
            repairBar3.gameObject.SetActive(true);
            filling3.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        inEvent = false;
        repairText1.gameObject.SetActive(false);
        repairBar1.gameObject.SetActive(false);
        repairText2.gameObject.SetActive(false);
        repairBar2.gameObject.SetActive(false);
        repairText3.gameObject.SetActive(false);
        repairBar3.gameObject.SetActive(false);
    }

    void reset()
    {
        if (repair != 101)
        {
            repair = 0;
        }
    }
}
