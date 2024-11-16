using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragGimmickController : MonoBehaviour
{
    private GameObject _movableObject = null;

    // Start is called before the first frame update
    void Start()
    {
        _movableObject = null;
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        if (hit2d)
            _movableObject = hit2d.collider.gameObject;
    }

    private void OnMouseDrag()
    {
        if (_movableObject == null) return;
        Vector3 mouseClickScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(mouseClickScreenPosition);
        float centerOfMouseY = mouseClickWorldPosition.y + transform.localScale.y / Common.Half;
        _movableObject.transform.position = new Vector3(mouseClickWorldPosition.x, centerOfMouseY, 0.0f);
    }

    private void OnMouseUp()
    {
        if (_movableObject == null) return;
        // ギミックをマウスから離したときの座標
        float gimmickReleasePositionX = _movableObject.transform.localPosition.x
            , gimmickReleasePositionY = _movableObject.transform.localPosition.y;
        // ギミックのパーツを配置する座標
        float gimmickClearPositionX = Common.StandardValue * 3, gimmickClearPositionY = 0f;
        DetermainClearPositionYValue(transform.parent.name, ref gimmickClearPositionY);
        // x範囲の許容値
        float gimmickClearPositionXMin = gimmickClearPositionX - gimmickClearPositionX / Common.Half
            , gimmickClearPositionXMax = gimmickClearPositionX + gimmickClearPositionX / Common.Half;
        // y範囲の許容値
        float gimmickClearPositionYMin = gimmickClearPositionY - Mathf.Abs(gimmickClearPositionY) / Common.Half
            , gimmickClearPositionYMax = gimmickClearPositionY + Mathf.Abs(gimmickClearPositionY) / Common.Half;

        if ((gimmickReleasePositionX >= gimmickClearPositionXMin || gimmickReleasePositionX <= gimmickClearPositionXMax)
            && (gimmickReleasePositionY >= gimmickClearPositionYMin || gimmickReleasePositionY <= gimmickClearPositionYMax))
        {
            _movableObject.transform.localPosition = new Vector3(gimmickClearPositionX, gimmickClearPositionY, 0f);
        }
    }

    /// <summary>
    /// ギミックの種類によってギミックを配置する座標を変更する
    /// </summary>
    /// <param name="parentObjectName">ギミックの名称（親オブジェクトから取得）</param>
    /// <param name="ClearPosition">ギミックを配置する座標</param>
    private void DetermainClearPositionYValue(in string parentObjectName, ref float ClearPosition)
    {
        // 親オブジェクトの名称で判別する
        if (parentObjectName.Contains(Common.HoleGimmickName)) ClearPosition = -1.4f;
        else if (parentObjectName.Contains(Common.NeedleGimmickName)) ClearPosition = 0f;
        else if (parentObjectName.Contains(Common.SlopeGimmickName)) ClearPosition = Common.StandardValue;
    }
}
