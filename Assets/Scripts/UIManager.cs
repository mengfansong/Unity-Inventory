using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        InventoryControl();
    }

    void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    private void Resume()
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
        //Debug.Log("R");
    }

    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
        //Debug.Log("P");
    }
   
}
