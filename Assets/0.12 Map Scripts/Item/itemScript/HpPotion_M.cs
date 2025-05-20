using UnityEngine;

public class HpPotion_M : Item,IItem
{
    [SerializeField] private int _hpRecoveryStat = 2;
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        if (player.Hp == player.Hpmax) return false;

        player.Hp += _hpRecoveryStat;
        return true;
    }
}
