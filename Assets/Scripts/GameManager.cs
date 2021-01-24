using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused=false;
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    //测试用Item
    public Item addItem_01;
    public Item removeItem_01;

    public ItemButton thisButton;
    public ItemButton[] itemButtons;

    private void DisplayItems()
    {
        for(int i = 0; i < slots.Length; i++)
        {

            if (i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                //数量的text
                slots[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(2).GetComponent<Text>().text = itemNumbers[i].ToString();
                //丢弃按钮
                slots[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                //数量的text
                slots[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(2).GetComponent<Text>().text = null;
                //丢弃按钮
                slots[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            
            
        }
    }

    public void AddItem(Item _item)
    {
        if (!items.Contains(_item))             //捡到了新的物品
        {
            items.Add(_item);
            itemNumbers.Add(1);
            //在末尾填一个1，新物品持有数量为1
            
        }
        else
        {
            Debug.Log("已经拥有了这类物品。");
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i] == _item)
                {
                    itemNumbers[i]++;
                }
            }     
        }
        DisplayItems();
    }

    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }

        ResetItemButton();

        DisplayItems();
    }

    private void Start()
    {
        DisplayItems();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        #region  测试捡和扔道具
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(addItem_01);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            RemoveItem(removeItem_01);
        }
        #endregion
    }

    public void ResetItemButton()
    {
        for(int i = 0; i < itemButtons.Length; i++)
        {
            if (i < items.Count)
            {
                itemButtons[i].thisItem = items[i];
            }
            else
            {
                itemButtons[i].thisItem = null;            }
        }
    }
}
