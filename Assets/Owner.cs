using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Owner : MonoBehaviour
{
    public static Owner i;

    public int money;

    void Start()
    {
        i = this;
        money = 88888;
        Invoke("UpdateMoney", 3);
    }
    public void UpdateMoney()
    {
        PlayfabManager.i.SendMoneyToServer(money);
        PlayfabManager.i.GetLeaderboard();
        PlayfabManager.i.SaveItemsOnMap();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
  
}
