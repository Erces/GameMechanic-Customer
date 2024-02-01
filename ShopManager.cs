using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager i;

    public List<Item> itemsSelling;
    public List<Item> itemsHolding;

    public int shelfCount;
    public List<Shelf> shelves;
    void Awake()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
