using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemSlot;
    public List<GameObject> itemList;
    public List<GameObject> emptySpace;
    Vector2 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = new Vector2 (50.0f, -14.0f);
        for(int k = 0; k < 4; k ++){
            GameObject newItemSlot = Instantiate(itemSlot);
            newItemSlot.GetComponent<Transform>().SetParent(this.gameObject.transform);
            newItemSlot.GetComponent<RectTransform>().anchoredPosition = currentPos;
            currentPos = currentPos + new Vector2(30.0f, 0f);

            emptySpace.Add(newItemSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
