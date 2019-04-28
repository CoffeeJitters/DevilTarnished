using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixing : MonoBehaviour
{
    public Text repairing;

    public Image repairButton;

    void Start()
    {
        repairing.gameObject.SetActive(false);
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
            repairing.gameObject.SetActive(true);
            repairButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        repairing.gameObject.SetActive(false);
        repairButton.gameObject.SetActive(false);
    }
}
