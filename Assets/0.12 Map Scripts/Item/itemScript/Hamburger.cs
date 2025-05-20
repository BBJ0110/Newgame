using UnityEngine;

public class Hamburger : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Hpmax += 4;
        player.Hp += 4;
        player.Speed -= 1f;
        return true;
    }
}
