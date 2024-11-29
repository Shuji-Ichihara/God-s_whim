using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickGimmickController : MonoBehaviour
{
    // マウスクリックで破壊するオブジェクト
    private GameObject _breakableObject = null;

    // Start is called before the first frame update
    void Start()
    {
        _breakableObject = null;
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        if (hit2d)
        {
            // オブジェクトを破壊
            _breakableObject = hit2d.collider.gameObject;
            Destroy(_breakableObject);
        }
    }
}
