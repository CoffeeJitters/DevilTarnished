using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixing : MonoBehaviour
{

    public Text repairing;
    public Image repairButton;
    private float repair;
    private float maxrepair;

    void Start()
    {
        repair = 0f;
        maxrepair = 100f;
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

            if (Input.GetButton("Fire1"))
            {
                repair += Time.deltaTime;
                Debug.Log("HIII");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        repairing.gameObject.SetActive(false);
        repairButton.gameObject.SetActive(false);
    }

    void fill()
    {
        Debug.Log("HIII");
    }
}
