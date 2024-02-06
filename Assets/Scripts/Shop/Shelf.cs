using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public List<ItemObject> itemList;
    public List<Transform> wayPoints;

    void Start()
    {
        foreach (Transform child in transform)
        {
            wayPoints.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsShelfEmpty()
    {
        foreach (var item in itemList)
        {
            if(item == null)
            return true;
        }
        if (itemList.Count == 0)
        {
            return true;

        }
        else
        {
            return false;

        }
    }
}
