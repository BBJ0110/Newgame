using UnityEngine;

public class WizardCape : Item, IItem
{
    public bool Use()
    {
        PlayerStatus player = PlayerStatus.Instance;
        player.IsWizardCape = true;
        return true;
    }
}
