
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    [SerializeField] private bool _isBossroom = false;
    [Header("enemysponpoint")]
    [SerializeField] private List<Transform> _enemySponPoint = new();
    [SerializeField] private List<GameObject> _sponEnmyList = new();


    [Header("clearCompen")]
    [SerializeField] private List<Transform> _compenSponPoint = new();

    [Header("etcItem")]
    [SerializeField] private List<Transform> _etcItemSponPoint = new();
    [SerializeField] private List<GameObject> _etcItem = new();


    private DoorManage _doorManage;
    private RandomItem _randomItem;
    private bool _isCurrentRoom = false;
    private void OnEnable()
    {
        _doorManage = GameObject.FindFirstObjectByType<DoorManage>().GetComponent<DoorManage>();
        _randomItem = GameObject.FindFirstObjectByType<RandomItem>().GetComponent<RandomItem>();
        EnemySpawn();

    }
    private void Update()
    {
        //이곳이 currentRoom이고 에너미가 없다면
        if (!GameObject.FindFirstObjectByType<Enemy>() && !_isCurrentRoom)
        {
            _isCurrentRoom = true;
            _doorManage.CurrentRoomClear();
            SponCompen();
            EtcItemSopwan();
            gameObject.SetActive(false);
        }
    }

    public void EnemySpawn()
    {
        for (int i = 0; i < _enemySponPoint.Count; i++)
            GameObject.Instantiate(_sponEnmyList[Random.Range(0, _sponEnmyList.Count)], _enemySponPoint[i]);
        _isCurrentRoom = false;
    }
    private void SponCompen()
    {
        for (int i = 0; i < _compenSponPoint.Count; i++)
        {
            Item item = _randomItem.GetRandomItem(_isBossroom ? Roomtype.BossRoom : Roomtype.NormalRoom) as Item;
            if (item == null) return;

            GameObject itembase = FindActivePool();
            itembase.SetActive(true);
            Sprite itemSprite = itembase.GetComponentInChildren<SpriteRenderer>().sprite = item.ItemData.Icon;
            itembase.transform.position = _compenSponPoint[i].position;
            itembase.transform.SetParent(_compenSponPoint[i]);
            Animator anima = itembase.GetComponentInChildren<Animator>();

            if (item.ItemData.type == ItemType.stat)
                anima.SetBool("isStat", true);

            Component additem = itembase.AddComponent(item.GetType());
            ((Item)additem).ItemData = item.ItemData;
        }
    }
    private void EtcItemSopwan()
    {
        if (_etcItem.Count == 0) return;
        for(int i = 0; i < _etcItemSponPoint.Count; i++)
        Instantiate(_etcItem[Random.Range(0,_etcItem.Count)], _etcItemSponPoint[Random.Range(0,_etcItemSponPoint.Count)]);
    }
    private GameObject FindActivePool()
    {
        if (ItempoolCreight.Instance._itemPool.Count != 0)
        {
            return ItempoolCreight.Instance._itemPool.Pop();
        }
        else
        {
            return Instantiate(ItempoolCreight.Instance.Itemprefab);
        }
    }
}
