using AOT;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItempoolCreight : MonoBehaviour
{
    public static ItempoolCreight Instance { get; private set; }
    [SerializeField] GameObject _itemprefab;
    public GameObject Itemprefab { get => _itemprefab; }
    public Stack<GameObject> _itemPool = new Stack<GameObject>();
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
}
