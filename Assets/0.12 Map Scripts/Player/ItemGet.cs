using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<IItem>(out IItem item))
        {
            PlayerStatus stat = PlayerStatus.Instance;
            int price = (item as Item).ItemData.Price, coin = stat.Coin;

            if (collision.CompareTag("Stend"))
            {
                if (coin < price) return;
                if (!item.Use()) return;
                stat.Coin -= price;
            }
            else
            {
                if (!item.Use()) return;
                ItempoolCreight.Instance._itemPool.Push(collision.gameObject);
            }
            collision.gameObject.SetActive(false);
            Destroy((MonoBehaviour)item);
            if ((item as Item).ItemData.type == ItemType.stat)
                PlayerInventory.Instance.AbbInventory(item as Item);




        }
    }
}
