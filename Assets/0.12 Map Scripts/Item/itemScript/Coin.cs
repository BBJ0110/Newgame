using UnityEngine;

public class Coin : Item, IItem
{

    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        if (player.Coin + ItemData.Price > player.Coinmax)
            return false;
        player.Coin += ItemData.Price;
        return true;
    }
}
