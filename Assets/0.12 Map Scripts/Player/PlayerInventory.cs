using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlayerInventory : MonoBehaviour
{
    static public PlayerInventory Instance { get; private set; }
    [field:SerializeField]public List<ItemData> Inventory { get; private set; } = new List<ItemData>();
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AbbInventory(Item item)
    {
        string name = item.ItemData.Name, explaint = item.ItemData.Explaint;
            Debug.Log(item);
        Inventory.Add(item.ItemData);
        ItemGetUI.Instance.itemGeting(name, explaint);
    }
    

}
