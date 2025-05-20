using UnityEngine;

public class MaidUniform : Item, IItem
{
    public bool Use()
    {
        var player = PlayerStatus.Instance;
        player.Hpmax += 4;
        player.Hp += 20;
        player.Dmg += 4;
        player.Knockback += 1;
        player.Speed += 2;
        return true;
    }
}
