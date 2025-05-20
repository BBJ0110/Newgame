using UnityEngine;

public class BlackNecklace : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Range += 2;
        player.AttackDelay -= 0.5f;
        return true;
    }
}
