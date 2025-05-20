using UnityEngine;

public class Meat : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Hpmax += 2;
        player.Hp += 2;
        return true;
    }
}