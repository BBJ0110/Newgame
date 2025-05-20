using System.Linq;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [Header("DoorWall")]
    [SerializeField] private GameObject _upDoorWall;
    [SerializeField] private GameObject _downDoorWall;
    [SerializeField] private GameObject _rightDoorWall;
    [SerializeField] private GameObject _leftDoorWall;

    [Header("BossDoor")]
    [SerializeField] private GameObject _upBossDoor;
    [SerializeField] private GameObject _downBossDoor;
    [SerializeField] private GameObject _rightBossDoor;
    [SerializeField] private GameObject _leftBossDoor;
    Room currentRoom = new();

    [Header("Door")]
    [SerializeField] private DoorBase[] doors;
    private bool _roomLock = false;
    public void SetLock(bool Lock,Room room)
    {
        currentRoom = room;
        _roomLock = Lock;
        for(int i = 0; i< doors.Length;i++)
        {
            doors[i].SetLockDoor(_roomLock,currentRoom);
        }
    }
    public GameObject GetDoors(Direction dir) => dir switch
    {
        Direction.up => _upDoorWall,
        Direction.down => _downDoorWall,
        Direction.right => _rightDoorWall,
        Direction.left => _leftDoorWall,
        _ => null
    };
    public void BossDoorsOn(Direction dir)
    {
        switch (dir)
        {
        case Direction.up: _upBossDoor.SetActive(true); break;
        case Direction.down: _downBossDoor.SetActive(true); break;
        case Direction.right: _rightBossDoor.SetActive(true); break;
        case Direction.left: _leftBossDoor.SetActive(true); break;
        default : Debug.Log("Null"); break;
        }
    }

}
