using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestedWheat : MonoBehaviour, IClick
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Crop crop;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        this._player = GameObject.Find("Character");
        this._inventory = GameObject.Find("Character").GetComponent<Inventory>();
    }

    public void OnClickAction()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 6.5f)
        {
            _inventory.AddCrop(crop);

            Destroy(this.gameObject);
        }
    }
}
