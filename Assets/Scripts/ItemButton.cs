using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;


public class ItemButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public int buttonID;

    public  Item thisItem;

    public Tooltips tooltip;

    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        GetThisItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButton()
    {
        GameManager.instance.RemoveItem(thisItem);

        thisItem = GetThisItem();
        if(thisItem!= null)
        {
            tooltip.ShowTooltip();
            tooltip.UpdateTooltip(GetDetailText(thisItem));
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }
        else
        {
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");
        }
    }

    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem= GameManager.instance.items[i];
                
            }
        }

        return thisItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(thisItem!= null)
        {
            //throw new System.NotImplementedException();
            Debug.Log("Enter " + thisItem.itemName + " Slot");

            tooltip.ShowTooltip();
            tooltip.UpdateTooltip(GetDetailText(thisItem));
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null,out position);
            tooltip.SetPosition(position);
        }
        
    }



    private string GetDetailText(Item _item)
    {
        if (_item == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("名称:{0}\n\n", _item.itemName);
            stringBuilder.AppendFormat("售价:{0}\n\n", _item.itemPrice);
            stringBuilder.AppendFormat("描述:{0}\n\n", _item.itemDescription);            
            return stringBuilder.ToString();
        }
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        if (thisItem != null)
        {
            //throw new System.NotImplementedException();
            Debug.Log("Exit " + thisItem.itemName + " Slot");

            tooltip.HideTooltip();
        }
        
    }
}
