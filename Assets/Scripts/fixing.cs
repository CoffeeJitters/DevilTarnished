using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixing : MonoBehaviour
{
   // public TextAlignment repairing;

    public Image repairButton;

    void Start()
    {
        repairButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("repair"))
        {
            repairButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        repairButton.gameObject.SetActive(false);

    }
}
