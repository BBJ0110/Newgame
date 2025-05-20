
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{

    public static PlayerStatus Instance { get; private set; }
    [Header("Stats")]
    [SerializeField] private int _hp,_hpMax;
    [SerializeField] private float _dmg, _range, _attackDelay, _bulletSpeed, _knockback;
    [SerializeField] private float _speed;
    [SerializeField] private int _coin,_coinMax;
    [SerializeField] private int _shield;
    [SerializeField] private float _invincibleTime;
    [SerializeField] private bool _isFly;
    public int Hpmax {
        get => _hpMax;
        set => _hpMax = Mathf.Clamp(value, 0, 40); }

    public int Hp {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, _hpMax); }

    public float Speed {
        get => _speed;
        set => _speed = Mathf.Max(value, 0.1f); }

    public float InvincibleTime {
        get => _invincibleTime; 
        set => _invincibleTime = Mathf.Max(value, 0.1f); }
    
    public int Coinmax {
        get => _coinMax;
        set => _coin = Mathf.Clamp(value, 1, 999); }
    public int Coin {
        get => _coin;
        set { _coin = Mathf.Clamp(value, 0, _coinMax); _moneyDmg = Coin / 4; }
    }
    public float Knockback{
        get => _knockback;
        set => _knockback = value;}
    public float Dmg{
        get => _dmg + _missingDmg + _moneyDmg;
        set =>  _dmg = Mathf.Max(value, 0.01f); 

    }
    public float BulletSpeed{
        get => _bulletSpeed;
        set => _bulletSpeed = value;}
    public float Range
    {
        get => _range;
        set => _range = Mathf.Max(value, 2);
    }
    public float AttackDelay
    {
        get => _attackDelay;
        set => _attackDelay = Mathf.Max(value, 0.01f);
    }
    public bool IsWizardCape { get; set; } = false;
    public bool IsMissing { get; set; } = false;
    public bool IsMoneyGun { get; set; } = false;

    private float _missingDmg = 0;
    private bool _isInvincible = false;
    private float _moneyDmg = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetFly();
    }
    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
            Speed -= 100;
    }
    #region Method

    public void BeingDamaged(int damge)
    {
        if (!_isInvincible)
        {
            _isInvincible = true;
            Damage(damge);
            StartCoroutine(startInvincible());
        }
    }

    private void Damage(int damge)
    {
        if(_shield != 0)
        {
            _shield--;
            return;
        }

        Hp -= damge;
        if (Hp <= 0)
            Dead();
    }
    private IEnumerator startInvincible()
    {
        yield return new WaitForSeconds(InvincibleTime);
        _isInvincible = false;
    }
    public bool IsFly
    {
        get => _isFly;
        set
        {
            _isFly = value;
            SetFly();
        }
    }
    private void SetFly()
    {
        int _player = LayerMask.NameToLayer("Player");
        int _obstruction = LayerMask.NameToLayer("Obstruction");
        int _void = LayerMask.NameToLayer("Void");

        Physics2D.IgnoreLayerCollision(_player, _obstruction, IsFly);
        Physics2D.IgnoreLayerCollision(_player, _void, IsFly);
    }
    
    public void SetMoveRoomItem()
    {
        if (IsWizardCape)
            _shield = 1;
        if (IsMissing)
        {
            _missingDmg = Random.Range(-_dmg/2, _dmg * 2);
            Debug.Log($"{_missingDmg} : {Dmg}");
        }
    }
    private void Dead()
    {
        Debug.Log("Dead");
    }
    #endregion
}
