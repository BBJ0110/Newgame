using UnityEngine;

public class BlackCape : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Dmg += 2;
        player.Speed += 1;
        return true;
    }
}
