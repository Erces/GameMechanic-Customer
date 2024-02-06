using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Owner : MonoBehaviour
{
    public static Owner i;

    public int money;

    void OnEnable()
    {
        EUActions.OnPlayerLogin += StartGetters;
    }
    void OnDisable()
    {
        EUActions.OnPlayerLogin -= StartGetters;
    }
    void Start()
    {
        i = this;
        
        //Invoke("UpdateMoney", 3);
    }
    public void StartGetters(){
        PlayfabManager.i.GetMoney();
        Debug.Log("Money: "+ money);

    }
    public void UpdateMoney()
    {
        PlayfabManager.i.SendMoneyToServer(money);
        PlayfabManager.i.GetLeaderboard();
        PlayfabManager.i.SaveItemsOnMap();
    }
    public void ManageMoney(int _money){
        PlayfabManager.i.UpdateMoney(_money);
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
  
}
