using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickField;
    [SerializeField] private Image _joystickArea;
    [SerializeField] private Image _joystick;

    [SerializeField] private Animator _animator;

    private Vector2 _joystickFieldStartPos;

    protected Vector2 _dirVector;

    [SerializeField] private Color _notActiveJoystickColor;
    [SerializeField] private Color _activeJoystickColor;
    [SerializeField] private Color _notActiveJoystickFieldColor;
    [SerializeField] private Color _activeJoystickFieldColor;

    private bool _joystickIsActive = false;

    private void Start()
    {
        Click();

        _joystickFieldStartPos = _joystickField.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickField.rectTransform, eventData.position, null, out joystickPos))
        {
            joystickPos.x = (joystickPos.x * 2 / _joystickField.rectTransform.sizeDelta.x);
            joystickPos.y = (joystickPos.y * 2 / _joystickField.rectTransform.sizeDelta.y);

            _dirVector = new Vector2(joystickPos.x, joystickPos.y);

            if (_dirVector.magnitude > 1.0f)
            {
                _dirVector = _dirVector.normalized;
            }

            _joystick.rectTransform.anchoredPosition = new Vector2(_dirVector.x * (_joystickField.rectTransform.sizeDelta.x / 2), _dirVector.y * (_joystickField.rectTransform.sizeDelta.y / 2));
        }

        _animator.SetBool("Move", true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click();

        Vector2 joystickFieldPos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out joystickFieldPos))
        {
            _joystickField.rectTransform.anchoredPosition = new Vector2(joystickFieldPos.x, joystickFieldPos.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickField.rectTransform.anchoredPosition = _joystickFieldStartPos;

        Click();

        _dirVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;

        _animator.SetBool("Move", false);
    }

    private void Click()
    {
        if (!_joystickIsActive)
        {
            
            _joystick.color = _notActiveJoystickColor;
            _joystickField.color = _notActiveJoystickFieldColor;
            _joystickIsActive = true;
        }
        else
        {
            _joystick.color = _activeJoystickColor;
            _joystickField.color = _activeJoystickFieldColor;
            _joystickIsActive = false;
        }
    }
}
