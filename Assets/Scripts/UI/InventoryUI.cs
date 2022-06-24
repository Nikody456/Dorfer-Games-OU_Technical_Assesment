using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    private TextMeshProUGUI _inventoryText;

    private void Awake()
    {
        _inventoryText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _inventoryText.text = _inventory.GetSize().ToString() + "/40";
    }
}
