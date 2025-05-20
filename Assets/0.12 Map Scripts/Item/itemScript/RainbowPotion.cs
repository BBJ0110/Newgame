using UnityEngine;

public class RainbowPotion : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Hpmax += 2;
        player.Hp += 2;
        player.Speed = 0.5f;
        return true;
    }
}
