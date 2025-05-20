using Unity.VisualScripting;
using UnityEngine;

public class Missing : Item, IItem
{
    public bool Use()
    {
        PlayerStatus.Instance.IsMissing = true;
        return true;
    }
}
