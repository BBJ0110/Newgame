using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GoldBar : Item, IItem
{
    public bool Use()
    {
        var player = PlayerStatus.Instance;
        player.Coin += 20;
        return true;
    }
}
