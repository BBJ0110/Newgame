using UnityEngine;

public class P : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Knockback += 1;
        player.Range += 2;
        player.AttackDelay -= 0.3f;
        player.Hp += 10;
        return true;
    }
}
