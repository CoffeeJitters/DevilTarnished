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
        if (Input.GetButton("Fire1") && inEvent == true)
        {
          //  repair += Time.deltaTime;
            Debug.Log("HIII");
            repairText.text = repair.ToString();
            repairBar.fillAmount = repair / maxrepair;
            repair += 10;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "repair")
        {
            inEvent = true;
            repairText.gameObject.SetActive(true);
            repairBar.gameObject.SetActive(true);
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
}
