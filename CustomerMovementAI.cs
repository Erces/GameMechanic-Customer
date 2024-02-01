using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovementAI : MonoBehaviour
{
    public enum Situation { Walking, Decide,Waiting,ThinkTime,Null,HeadingToOwner }
    public Situation currentSituation;

    public NavMeshAgent agent;
    private Customer customer;

    private Shelf selectedShelf;
    public Transform selectedWaypoint;

    private float thinkTime;
    private float thinkTimer;
    void Start()
    {
        currentSituation = Situation.Null;
        customer = GetComponent<Customer>();
        agent = GetComponent<NavMeshAgent>();

        thinkTime = customer.thinkTime;
        thinkTimer = customer.thinkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSituation == Situation.ThinkTime)
        {
            //transform.LookAt(selectedShelf.transform.position);

            thinkTimer -= Time.deltaTime;
            if(thinkTimer<= 0)
            {
                currentSituation = Situation.Decide;

                thinkTimer = thinkTime;
            }
        }
        if(currentSituation == Situation.Decide)
        {
            Decide();
        }
        if(Mathf.Abs(Vector3.Distance(transform.position,selectedWaypoint.position)) < 1.5f && currentSituation == Situation.Walking)
        {
            Debug.Log("Reached");
            currentSituation = Situation.ThinkTime;
            //Decide();
        }
        if(currentSituation == Situation.HeadingToOwner)
        {
            agent.SetDestination(CustomerHandler.i.shopLines[0].transform.position);
        }
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

    public void PickItem()
    {

    }
    public void Wander()
    {
        currentSituation = Situation.Walking;
        foreach (var item in customer.myShelfList)
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
        
    }
    public void HeadToShopOwner()
    {

    }
}
