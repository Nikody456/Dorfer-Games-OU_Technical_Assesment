using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _coinImage;
    [SerializeField] private GameObject _coinTextImage;
    public static CoinsManager instance;

    private TextMeshProUGUI _coinsText;

    public int _totalCoins;
    private GameObject _coinObj;

    private void Awake()
    {
        instance = this;
        _coinsText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _coinsText.text = _totalCoins.ToString();
        
    }

    public void AddCoins(int price)
    {
        StartCoroutine(CoinAnimation(price));
    }

    private IEnumerator CoinAnimation(int price)
    {
        _coinObj = Instantiate(_coin, new Vector3(-2.091736f, -1.734497f, 0f), Quaternion.identity);
        _coinObj.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        _coinObj.transform.DOMove(_coinImage.transform.position, 0.5f);


        yield return new WaitForSeconds(0.5f);

        _coinTextImage.transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.1f).OnComplete(() =>
        {
            _coinTextImage.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        });

        _totalCoins += price;

        _coinsText.text = _totalCoins.ToString();
        Destroy(_coinObj);
    }
}
