using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Sprite _basicStand;
    [SerializeField] Sprite _statStand;
    [SerializeField] Sprite _gunstand;
    [SerializeField] TextMeshPro text; 
    private RandomItem _randomItem;
    SpriteRenderer stand;
    SpriteRenderer itemSprite;
    Item _currentItem;
    private void Awake()
    {
        _randomItem = FindFirstObjectByType<RandomItem>();
    }
    private void Start()
    {
        stand = GetComponentInParent<SpriteRenderer>();
        itemSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        IItem itemScripte = _randomItem.GetRandomItem(Roomtype.ShopRoom);
        if (itemScripte == null) gameObject.SetActive(false);
        ItemSetting((Item)itemScripte);

    }
    private void ItemSetting(Item item)
    {
        itemSprite.sprite = (item).ItemData.Icon;
        stand.sprite = StandSprite(item);
        Component additem = gameObject.AddComponent(item.GetType());
        ((Item)additem).ItemData = item.ItemData;
        _currentItem = (Item)additem;
        text.text = _currentItem.ItemData.Price.ToString();
    }
    private Sprite StandSprite(Item item) => item.ItemData.type switch
    {
        ItemType.stat => _statStand,
        _ => _basicStand
    };
}
