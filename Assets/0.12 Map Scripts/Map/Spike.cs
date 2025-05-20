using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Coroutine _damageCoroutione;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(_damageCoroutione == null)
                _damageCoroutione = StartCoroutine(SpikeDamaged());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (_damageCoroutione != null)
                StopCoroutine(_damageCoroutione);
            _damageCoroutione = null;
        }
    }
    private IEnumerator SpikeDamaged()
    {
        while(true)
        {
            PlayerStatus.Instance.BeingDamaged(1);
            yield return null;
        }
    }
}
