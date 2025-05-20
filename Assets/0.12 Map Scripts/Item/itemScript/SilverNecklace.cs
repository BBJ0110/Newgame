using UnityEngine;

public class SilverNecklace : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.InvincibleTime += 0.2f;
        return true;
    }
}
