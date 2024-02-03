using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemObject : MonoBehaviour
{

    public Item item;
    public bool PickedUp;
    public Transform lockPos = null;
    private void Update()
    {
        transform.position = lockPos.position;
    }
    public void PickObject(Customer _customer)
    {
        PickedUp = true;
        lockPos = _customer.carryPos;
    }
}
