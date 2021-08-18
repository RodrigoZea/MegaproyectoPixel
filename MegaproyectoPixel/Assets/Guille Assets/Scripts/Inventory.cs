using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Instance
    public static Inventory instance;

    public List<gunsData> inventory = new List<gunsData>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory.Add(WeaponsDatabase.instance.guns[0]);
        inventory.Add(WeaponsDatabase.instance.guns[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
