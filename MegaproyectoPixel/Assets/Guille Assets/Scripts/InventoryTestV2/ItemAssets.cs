using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite sword;
    public Sprite health;
    public Sprite ammo;
    public Sprite mana;
    public Sprite coin;
    public Sprite medkit;



}
