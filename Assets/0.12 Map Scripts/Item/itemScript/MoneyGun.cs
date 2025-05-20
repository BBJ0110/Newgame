using UnityEngine;

public class MoneyGun : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.IsMoneyGun = true;
        return true;
    }
}
