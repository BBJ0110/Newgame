using UnityEngine;

public class RewerdSpwnPoint : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _spwnItem;
    public void ItemSpwn(IItem item)
    {
        if (_spwnItem == null) _spwnItem = item as MonoBehaviour;

    }
}
