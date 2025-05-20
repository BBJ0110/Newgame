using UnityEngine;

public class Mushroom : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.Speed += 1;
        player.gameObject.transform.localScale += new Vector3(1, 1,0);
        return true;
    }
}
