using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _sickle;

    private float _currentGravity = 0.0f;
    [SerializeField] private float gravityForce = 20.0f;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleGravity();
    }

    public void MoveCharacter(Vector3 moveDir)
    {
        moveDir = moveDir * _movementSpeed;
        moveDir.y = _currentGravity;
        _controller.Move(moveDir * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 moveDir)
    {
        if (Vector3.Angle(transform.forward, moveDir) > 0)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDir, _rotationSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    private void HandleGravity()
    {
        _currentGravity -= gravityForce * Time.deltaTime;

    }

    public IEnumerator HarvestCrop(Vector3 destination, GameObject crop, Crop cropScriptableObject, Mud mud)
    {
        if (!this.GetComponent<Animator>().GetBool("isHarvesting"))
        {
            transform.LookAt(crop.transform.position);
            this.GetComponent<Animator>().SetBool("isHarvesting", true);
            _sickle.SetActive(true);

            yield return new WaitForSeconds(1);

            _sickle.SetActive(false);
            Destroy(crop);
            this.GetComponent<Animator>().SetBool("isHarvesting", false);

            mud._stage = "EMPTY";
            cropScriptableObject.DropCrop(this.transform);
        }
    }
}
