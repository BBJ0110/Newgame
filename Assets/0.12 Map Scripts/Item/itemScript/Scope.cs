using UnityEngine;

public class Scope : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Range += 1;
        return true;
    }
}
