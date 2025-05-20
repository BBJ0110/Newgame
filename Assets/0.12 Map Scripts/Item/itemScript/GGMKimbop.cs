using UnityEngine;

public class GGMKimbop : Item, IItem
{
    
    public bool Use()
    {
        Debug.Log("기분 좋다");
        return true;
    }
}

