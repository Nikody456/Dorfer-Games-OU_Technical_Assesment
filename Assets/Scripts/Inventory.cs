using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Crop> _inventoryItems = new List<Crop>();

    public void AddCrop(Crop crop)
    {
        if (_inventoryItems.Count() < 40)
        {
            _inventoryItems.Add(crop);
        }
    }

    private void Update()
    {
        Debug.Log(_inventoryItems.Count());
    }

    public IEnumerator SellCropsAction()
    {
        CoinsManager.instance.AddCoins(_inventoryItems.Last().price);
        _inventoryItems.Remove(_inventoryItems.Last());


        yield return new WaitForSeconds(1f);
    }

    public int GetSize()
    {
        return _inventoryItems.Count();
    }
}
