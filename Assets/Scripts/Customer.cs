using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public enum ItemSituation { WantToBuy,WantToSell}
    public ItemSituation customerSituation;

    [Range(0,10)]public int bargainLevel;
    public float money;
    public float maxOfferToItem;

    public float thinkTime;
    public float thinkTimer;

    public ItemObject selectedItem;

    private CustomerMovementAI moveAI;
    private CustomerThinkAI thinkAI;

    public Transform carryPos;

    public List<Shelf> myShelfList;
    private void Awake()
    {
    }
    void Start()
    {

        foreach (var item in ShopManager.i.shelves)
        {
            myShelfList.Add(item);
        }
        myShelfList = myShelfList.OrderBy(x => Random.value).ToList();

        moveAI = GetComponent<CustomerMovementAI>();
        thinkAI = GetComponent<CustomerThinkAI>();

        switch (customerSituation)
        {
            case ItemSituation.WantToBuy:
                StartShoping();
                break;
            case ItemSituation.WantToSell:
                break;
            default:
                break;

        }
    }

    private void StartShoping()
    {
        moveAI.Wander();
    }
    

}
