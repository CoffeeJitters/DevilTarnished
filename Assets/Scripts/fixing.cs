using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fixing : MonoBehaviour
{
    public GameObject Doors;
    public GameObject upperDoor;
    public GameObject lowerDoor;
    public Text repairText1;
    public Image repairBar1;
    public Image filling1;
    public Text repairText2;
    public Image repairBar2;
    public Image filling2;
    /*
    public Text repairText3;
    public Image repairBar3;
    public Image filling3;
    */
    private float repair1;
    private float repair2;
    //private float repair3;
    
    private float maxrepair;
    bool inEvent1;
    bool inEvent2;
    //bool inEvent3;
    public float repar;

    void Start()
    {
        repair1 = 0f;
        repair2 = 0f;
  //      repair3 = 0f;
        maxrepair = 100f;
        upperDoor.gameObject.SetActive(false);
        lowerDoor.gameObject.SetActive(false);
        filling1.gameObject.SetActive(false);
        repairText1.gameObject.SetActive(false);
        repairBar1.gameObject.SetActive(false);
        filling2.gameObject.SetActive(false);
        repairText2.gameObject.SetActive(false);
        repairBar2.gameObject.SetActive(false);/*
        filling3.gameObject.SetActive(false);
        repairText3.gameObject.SetActive(false);
        repairBar3.gameObject.SetActive(false);*/

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && inEvent1 == true && repair1 < 101)
        {
            filling1.fillAmount = repair1 / maxrepair;
            repair1 += repar;
            if (repair1 == 100)
            {
                repairText1.text = "Locked";
                upperDoor.gameObject.SetActive(true);
                lowerDoor.gameObject.SetActive(true);
            }
        }
        if (inEvent1 == true && !(Input.GetButton("Fire1")))
        {
            if (repair1 < 100)
            {
                repair1 = 0;
                filling1.fillAmount = 0;
            }
        }
        if (Input.GetButton("Fire1") && inEvent2 == true && repair2 < 101)
        {
            filling2.fillAmount = repair2 / maxrepair;
            repair2 += repar;
            if (repair2 == 100)
            {
                repairText2.text = "Opened!";
                Doors.gameObject.SetActive(false);
            }
        }
        if (inEvent2 == true && !(Input.GetButton("Fire1")))
        {
            if (repair2 < 100)
            {
                repair2 = 0;
                filling2.fillAmount = 0;
            }
        }
        /*     if (Input.GetButton("Fire1") && inEvent3 == true && repair3 < 101)
             {
                 filling3.fillAmount = repair3 / maxrepair;
                 repair3 += repar;
                 if (repair3 == 100)
                 {
                     repairText3.text = "Fixed!!";
                 }
             }
             if (inEvent3 == true && !(Input.GetButton("Fire1")))
             {
                 if (repair3 < 100)
                 {
                     repair3 = 0;
                     filling3.fillAmount = 0;
                 }
             }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "repair1")
        {
            inEvent1 = true;
            repairText1.gameObject.SetActive(true);
            repairBar1.gameObject.SetActive(true);
            filling1.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "repair2")
        {
            inEvent2 = true;
            repairText2.gameObject.SetActive(true);
            repairBar2.gameObject.SetActive(true);
            filling2.gameObject.SetActive(true);
        }
 /*       if (other.gameObject.tag == "repair3")
        {
            inEvent3 = true;
            repairText3.gameObject.SetActive(true);
            repairBar3.gameObject.SetActive(true);
            filling3.gameObject.SetActive(true);
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        inEvent1 = false;
        inEvent2 = false;
        //       inEvent3 = false;
        repairText1.gameObject.SetActive(false);
        repairBar1.gameObject.SetActive(false);
        filling1.gameObject.SetActive(false);
        repairText2.gameObject.SetActive(false);
        repairBar2.gameObject.SetActive(false);
        filling2.gameObject.SetActive(false);
        /*      repairText3.gameObject.SetActive(false);
              repairBar3.gameObject.SetActive(false);
              filling3.gameObject.SetActive(false);*/
    }
}
