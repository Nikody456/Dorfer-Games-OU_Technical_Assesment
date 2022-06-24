using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator _anim;

    private void Update()
    {
        if (!_anim.GetBool("isHarvesting"))
        {
            if (_dirVector.x != 0 || _dirVector.y != 0)
            {
                characterMovement.MoveCharacter(new Vector3(_dirVector.x, 0, _dirVector.y));
                characterMovement.RotateCharacter(new Vector3(_dirVector.x, 0, _dirVector.y));
            }
            else
            {
                characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            }
        }
    }
}
