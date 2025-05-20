using UnityEngine;

public class Monster : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Speed += 1;
        return true;
    }
}
