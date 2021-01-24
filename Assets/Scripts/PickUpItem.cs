using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject pickupEffect;
    public Item itemData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.instance.items.Count < GameManager.instance.slots.Length)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddItem(itemData);
            }
            else
            {
                Debug.Log("you cannot take anymore!");
            }
            
        }
    }
}
