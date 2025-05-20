using UnityEngine;
using UnityEngine.Rendering;

public class ItemScript : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        return true;
    }
}
