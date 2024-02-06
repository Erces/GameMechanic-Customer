using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovementAI : MonoBehaviour
{
    public enum Situation { Walking, Decide,Waiting,ThinkTime,Null,HeadingToOwner,HeadingToExit }
    public Situation currentSituation;

    public NavMeshAgent agent;
    private Customer customer;

    private Shelf selectedShelf;
    public Transform selectedWaypoint;

    private float thinkTime;
    private float thinkTimer;
    void Start()
    {
        currentSituation = Situation.Walking;
        customer = GetComponent<Customer>();
        agent = GetComponent<NavMeshAgent>();

        thinkTime = customer.thinkTime;
        thinkTimer = customer.thinkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentSituation){
            case Situation.Null:
            break;
            case Situation.Walking:
            Walk();
            break;
            case Situation.ThinkTime:
            Think();
            break;
            case Situation.Decide:
            Decide();
            break;
            case Situation.HeadingToOwner:
            HeadToShopOwner();
            break;
            case Situation.HeadingToExit:
            HeadToExit();
            break;
        }
    }
    public void Walk(){
        if(selectedWaypoint != null && Mathf.Abs(Vector3.Distance(transform.position,selectedWaypoint.position)) < 1.5f){
            Debug.Log("Reached");
            currentSituation = Situation.ThinkTime;
        }
        agent.SetDestination(selectedWaypoint.position);
    }
    public void Decide()
    {
        foreach (var item in selectedShelf.itemList)
        {
            var rndm = Random.Range(0, 100);
            if (item.item.interestEffect > rndm)
            {
                switch (customer.bargainLevel)
                {
                    case 1:
                        customer.maxOfferToItem = item.item.price +( (item.item.price /100) * 25);
                        break;
                    case 2:
                        customer.maxOfferToItem = item.item.price + ((item.item.price / 100) * 15);
                        break;
                    case 3:
                        customer.maxOfferToItem = item.item.price;
                        break;
                    case 4:
                        customer.maxOfferToItem = item.item.price - ((item.item.price / 100) * 25);
                        break;
                    case 5:
                        customer.maxOfferToItem = item.item.price - ((item.item.price / 100) * 35);
                        break;
                    default:
                        customer.maxOfferToItem = item.item.price;
                        break;
                }
                customer.selectedItem = item;
                item.PickObject(customer);
                currentSituation = Situation.HeadingToOwner;
                return;


            }
        }
    }
    public void Think(){
            thinkTimer -= Time.deltaTime;
            if(thinkTimer<= 0)
            {
                currentSituation = Situation.Decide;

                thinkTimer = thinkTime;
            }
    }
    public void PickItem()
    {

    }
    public void Wander(List<Shelf> shelves)
    {
        
        currentSituation = Situation.Walking;
        
        foreach (var item in shelves)
        {
            if (item.IsShelfEmpty())
            {
                Debug.Log("Empty");

                continue;
            }

            else
            {
                Debug.Log("Not Empty");
                selectedShelf = item;
                break;
            }
                
        }
        Debug.Log(selectedShelf.name);
        var rndm = Random.Range(0, selectedShelf.wayPoints.Count);
        if(selectedShelf){
            agent.SetDestination(selectedShelf.wayPoints[0].position);
        selectedWaypoint = selectedShelf.wayPoints[0];
        }
        else{
            currentSituation = Situation.HeadingToExit;
        }
        
    }
    public void HeadToShopOwner()
    {
        if(Mathf.Abs(Vector3.Distance(transform.position,selectedWaypoint.position)) < 1.5f){
            StartCoroutine("WaitForExit");
        }
        agent.SetDestination(CustomerHandler.i.shopLines[0].transform.position);
    }
    public IEnumerator WaitForExit(){
        yield return new WaitForSeconds(3);
        currentSituation = Situation.HeadingToExit;
        customer.SellItem();
    }
    public void HeadToExit(){
        if(Mathf.Abs(Vector3.Distance(transform.position,CustomerSpawner.i.exitPos.position)) < 1.5f){
            EUActions.OnCustomerExit?.Invoke();
            Destroy(gameObject);
        }
        agent.SetDestination(CustomerSpawner.i.exitPos.position);
    }
    
}
