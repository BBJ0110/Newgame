using UnityEngine;

public class HpPotion_L : Item, IItem
{
    [SerializeField] private int _hpRecoveryStat = 3;
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        if (player.Hp == player.Hpmax) return false;

        player.Hp += _hpRecoveryStat;
        return true;
    }
}
