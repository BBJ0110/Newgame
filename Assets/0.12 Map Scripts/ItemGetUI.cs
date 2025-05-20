
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ItemGetUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText, _explainText;
    public static ItemGetUI Instance { get; private set;}
    private void Awake()
    {
        gameObject.SetActive(false);
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


    public void itemGeting(string name, string explain)
    {
        gameObject.SetActive(false);
        _nameText.text = name;
        _explainText.text = explain;
        gameObject.SetActive(true);
        StartCoroutine(Texting());
    }
    private IEnumerator Texting()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }

}
