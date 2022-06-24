using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mud : MonoBehaviour, IClick
{
    [SerializeField] private Crop _crop;
    [SerializeField] private GameObject _player;
    [SerializeField] private CharacterMovement characterMovement;
    private GameObject _wheat;
    public string _stage = "EMPTY";

    private void Start()
    {
        _stage = "EMPTY";
    }

    public void OnClickAction()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 6.5f)
        {
            if (_stage == "EMPTY")
            {
                _wheat = Instantiate(_crop._crop, new Vector3(this.transform.position.x, 3, this.transform.position.z), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
                StartCoroutine(Grow(_wheat.transform, _crop));
            }
            else if (_stage == "DONE")
            {
                StartCoroutine(characterMovement.HarvestCrop(this.transform.position, _wheat, _crop, this));
            }
        }
    }

    private void Update()
    {

    }

    private IEnumerator Grow(Transform cropTransform, Crop crop)
    {
        cropTransform.DOMove(new Vector3(cropTransform.transform.position.x, 6, cropTransform.transform.position.z), 10);
        _stage = "GROW";
        yield return new WaitUntil(() => cropTransform.transform.position.y == 6);

        _stage = "DONE";
    }

}
