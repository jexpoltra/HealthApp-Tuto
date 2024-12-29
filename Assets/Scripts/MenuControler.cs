using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{

    public GameObject appPages;
    private string currentPage;
    public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OpenAppPage(GameObject appPageToOpen)
    {
        if (appPageToOpen == null)
        {
            Debug.Log("No app page selected to open");
        }
        else
        {
            SetChildrenState(appPages, false);
            appPageToOpen.gameObject.SetActive(true);
            currentPage = appPageToOpen.name;
            Debug.Log($"Current Page Set to: {currentPage}");

            if (appPageToOpen.name != "pageHome")
            {
                backButton.SetActive(true);
            }
            else
            {
                backButton.SetActive(false);
            }

        }
    }






        public void SetChildrenState(GameObject parentObject, Boolean activate)
        {
            foreach (Transform child in parentObject.transform)
            {
                child.gameObject.SetActive(activate);
            }
        }
    }

