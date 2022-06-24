using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private Camera _mainCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DetectObject();
    }

    private void DetectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    IClick click = hit.collider.gameObject.GetComponent<IClick>();
                    if (click != null)
                        click.OnClickAction();
                }
            }
        }
    }
}
