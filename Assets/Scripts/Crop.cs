using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Scriptable Objects/Crop")]
public class Crop : ScriptableObject
{
    public GameObject _crop;
    public GameObject _harvestedCrop;
    public int price;

    public void DropCrop(Transform dropPosition)
    {
        Vector3 _offset = new Vector3(2.0f, 2.0f, 2.0f);
        Instantiate(_harvestedCrop, new Vector3(dropPosition.position.x + 2.0f, dropPosition.position.y + 4.0f, dropPosition.position.z), Quaternion.identity);
    }
}
