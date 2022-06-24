using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Button _sellSutton;

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, this.transform.position) < 12.0f)
        {
            if (_inventory.GetSize() > 0)
            {
                _sellSutton.gameObject.SetActive(true);
            }
            else
                _sellSutton.gameObject.SetActive(false);
        }
        else
            _sellSutton.gameObject.SetActive(false);
    }

    public void Sell()
    {
        if (_inventory.GetSize() > 0)
        {
            StartCoroutine(_inventory.SellCropsAction());
        }
    }
}
