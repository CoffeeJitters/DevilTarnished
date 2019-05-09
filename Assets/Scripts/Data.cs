using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject chipData;
    public GameObject tableData;
    public Image pickUpImage;
    public Text pickUpText;
    bool event1;
    // Start is called before the first frame update
    void Start()
    {
        chipData.gameObject.SetActive(false);
        pickUpImage.gameObject.SetActive(false);
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && event1 == true)
        {
            pickUpText.text = "Retrieved Data!";
            chipData.gameObject.SetActive(true);
            tableData.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "data")
        {
            event1 = true;
            pickUpImage.gameObject.SetActive(true);
            pickUpText.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        pickUpImage.gameObject.SetActive(false);
        pickUpText.gameObject.SetActive(false);
    }
}
