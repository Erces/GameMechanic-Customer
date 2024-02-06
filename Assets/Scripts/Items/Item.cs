using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public GameObject visualObject;
    public enum Situation{ ForSell,ForBuy}
    public Situation currentSituation;

    public int price;
    
    
    public int rarity;
    public int interestEffect;



    
}
