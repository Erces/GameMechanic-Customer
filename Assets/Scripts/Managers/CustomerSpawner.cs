using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner i;
    [SerializeField] private GameObject customer;
    [SerializeField] private Transform customerSpawnPos;
    public Transform exitPos;

    void Awake()
    {
        i = this;
    }
    void OnEnable()
    {
        EUActions.OnCustomerExit += SpawnCustomer;
        EUActions.OnPlayerLogin += SpawnCustomer;

    }
    void OnDisable()
    {
        EUActions.OnCustomerExit -= SpawnCustomer;
        EUActions.OnPlayerLogin -= SpawnCustomer;
    }


    // Update is called once per frame
    public void SpawnCustomer(){
        var cstmr = (GameObject)Instantiate(customer,customerSpawnPos.position,customerSpawnPos.rotation);
    }
}
