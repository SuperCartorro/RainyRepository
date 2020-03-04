using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleLever : MonoBehaviour
{
    public bool isOn = false;
    public GameObject[] spriteArray;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //void OnTriggerEnter2D(Collider2D lookForPlayer)
        {

            if (isOn == true)
            {
                platform.SetActive(true);

                spriteArray[1].SetActive(true);
                spriteArray[0].SetActive(false);

            }
            if (isOn == false)
            {
                platform.SetActive(false);

                spriteArray[0].SetActive(true);
                spriteArray[1].SetActive(false);
            }
        }
        //Debug.Log("it's" + lookForPlayer);

    }



    public void checkThePlayer()
    {
        Debug.Log("Tried Final");

        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Success");
            isOn = !isOn;
            return;
        }
        }
    }
