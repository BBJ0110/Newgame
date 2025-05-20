using UnityEngine;

public class SilverBar : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Coin += 10;
        return true;
    }
}
