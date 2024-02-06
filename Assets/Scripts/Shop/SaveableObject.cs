using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    public string name;
    public int x;
    public int y;
    public int z;


    void Start()
    {
        PlayfabManager.i.so.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SaveableObject(string name,int x,int y,int z)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public SaveableObject ReturnClass()
    {
        return new SaveableObject(name,x,y,z);
    }
}
