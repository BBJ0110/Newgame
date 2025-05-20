using UnityEngine;

public class WingDrink : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.IsFly = true ;
        return true;
    }
}
