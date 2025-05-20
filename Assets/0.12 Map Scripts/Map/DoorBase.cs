using System;
using System.Net.NetworkInformation;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorBase : MonoBehaviour
{
    [SerializeField] private Direction _direction;
    private Roomtype _doortype;
    private DoorManage _manager;
    
    private void Awake()
    {
        _manager = GameObject.FindFirstObjectByType<DoorManage>().GetComponent<DoorManage>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _manager.RoomMove(collision, _direction);
        }
    }
    public void SetLockDoor(bool isLock, Room room)
    {
        if (!room._connectRoom.TryGetValue(_direction,out _)) return;
        gameObject.GetComponent<TilemapRenderer>().enabled = !room._isClearRoom || room._connectRoom[_direction]._isBossRoom || room._connectRoom[_direction]._isShopRoom || room._isShopRoom || room._isBossRoom;
     
    }
}
