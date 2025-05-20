
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum ItemType {coin, potion, stat}
public enum RewardType {coin, potion, stat, boss, shop, non}
public enum Roomtype {BossRoom, ShopRoom, NormalRoom}

public class RandomItem : MonoBehaviour
{
    [SerializeField] private List<RoomProportion> _roomProportion;
    [SerializeField] private List<ItemGrideProportion> _itemGrideProportion;
    [SerializeField] private List<MonoBehaviour> _appearitemlist;

    private List<IItem> _statitemlist = new() , _bossitemlist = new(), _shopitemlist =new(), _overitemlist = new();
    private List<IItem> _potionList =new();
    private List<IItem> _coinList = new();

    private Dictionary<ItemType, Dictionary<ItemGrade, int>> itemproprtion = new Dictionary<ItemType, Dictionary<ItemGrade, int>>();
    private Dictionary<Roomtype, Dictionary<RewardType, int>> roomproprtion = new Dictionary < Roomtype, Dictionary<RewardType, int>>();

    
    private void Start()
    {
        ListSetting();
    }
    public IItem GetRandomItem(Roomtype room)
    {

        int probab = Random.Range(0, roomproprtion[room].Values.Sum());
        int sum = 0;
        RewardType compeclassif = RewardType.non;
        foreach (var classif in roomproprtion[room])
        {
            sum += classif.Value;
            if (probab < sum)
            {
                compeclassif = classif.Key;
                break;
            }
        }
        if (compeclassif == RewardType.non) return null;
        
        IItem compeitem = GetRandomReward(compeclassif);
        if (((Item)compeitem).ItemData.type == ItemType.stat)
            RemoveItemList(compeitem as Item);
        
        return compeitem;

    }

    private IItem GetRandomReward(RewardType rewardType) => rewardType switch
    {
        RewardType.stat => _statitemlist.Count != 0? _statitemlist[Random.Range(0, _statitemlist.Count)]: _overitemlist[Random.Range(0, _overitemlist.Count)],
        RewardType.boss => _bossitemlist.Count != 0? _bossitemlist[Random.Range(0, _bossitemlist.Count)]: GetRandomReward(RewardType.stat),
        RewardType.shop => _shopitemlist.Count != 0? _shopitemlist[Random.Range(0, _shopitemlist.Count)]: GetRandomReward(RewardType.stat),
        RewardType.coin => _coinList[Random.Range(0, _coinList.Count)],
        RewardType.potion => _potionList[Random.Range(0, _potionList.Count)],
        _=>null
        
    };

    private void RemoveItemList(Item item)
    {
        for (int i = 0; i < Finditemproprtion(item); i++)
            FindItemList(item).Remove((IItem)item);
    }

    private void RemoveAppearanceItemList(MonoBehaviour removeItem)
    {
        _appearitemlist.Remove(removeItem);
    }

    private void ListSetting()
    {
        foreach(var a in _itemGrideProportion)
        {
            if(!itemproprtion.TryGetValue(a.WhatItemType ,out Dictionary<ItemGrade,int> d))
            {
                d = new Dictionary<ItemGrade, int>();
                itemproprtion[a.WhatItemType] = d;
            }
            foreach(GradeWeight b in a.Weight)
            {
                itemproprtion[a.WhatItemType][b.Grade] = b.Weight ;
            }
        }

            foreach (var a in _roomProportion)
        {
            if(!roomproprtion.TryGetValue(a.Room, out Dictionary<RewardType, int> b))
            {
                b = new Dictionary<RewardType, int>();
                roomproprtion[a.Room] = b;
            }
            foreach (var d in a.itemProportions)
            {
                roomproprtion[a.Room][d.Reward] = d.Propor;
            }
        }
        foreach (MonoBehaviour c in _appearitemlist)
        {
            if(c is Item a)
            {
                if (a.ItemData.IsOverItem)
                {
                    _overitemlist.Add(a as IItem);
                }
                if (PlayerInventory.Instance.Inventory.Contains(a.ItemData))
                    continue;

                for (int i = 0; i < Finditemproprtion(a); i++)
                    FindItemList(a).Add(a as IItem);
            }
        }
    }

    private int Finditemproprtion(Item a)
    {
        if(!itemproprtion.TryGetValue(a.ItemData.type, out Dictionary<ItemGrade,int> b))
        {
            b = new Dictionary<ItemGrade, int>();
            itemproprtion[a.ItemData.type] = b;
        }
        return itemproprtion[a.ItemData.type][a.ItemData.Grade];
    }
    private List<IItem> FindItemList(Item item)
    {
        switch (item.ItemData.type)
        {
            case ItemType.stat:
                return NewMethod(item);
            case ItemType.potion: return _potionList;
            case ItemType.coin: return _coinList;
            default: return null;
        }
    }

    private List<IItem> NewMethod(Item item)
    {
        switch (item.ItemData.Grade)
        {
            case ItemGrade.Shop: return _shopitemlist;
            case ItemGrade.Boss: return _bossitemlist;
            default: return _statitemlist;
        }
    }

}
