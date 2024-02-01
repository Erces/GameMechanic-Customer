using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerHandler : MonoBehaviour
{
    public static CustomerHandler i;
    public List<Customer> customerList;
    public List<Transform> wanderPoints;
    public List<ShopLine> shopLines;

    void Awake()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (customerList.Count == 0)
            return;
        foreach (var item in customerList)
        {
            switch (item.customerSituation)
            {
                case Customer.ItemSituation.WantToBuy:
                    break;
                case Customer.ItemSituation.WantToSell:
                    break;
                default:
                    break;
            }
        }
    }
}
