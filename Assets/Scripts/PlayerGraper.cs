using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGraper
{
    public PlayerGraper(SpringJoint2D joint, PlayerConfig config, Transform transform, LineRenderer lineRenderer)
    {
        _joint = joint;
        _config = config;
        _transform = transform;
        _lineRenderer = lineRenderer;
    }

    private SpringJoint2D _joint;
    private PlayerConfig _config;
    private Transform _transform;
    private LineRenderer _lineRenderer;

    public void Tick()
    {
        if (_joint.enabled)
        {
            _joint.distance -= _config.WindingSpeed * Time.deltaTime;
            if (_joint.distance < 0.5f)
            {
                _joint.distance = 0.5f;
            }
        }
        DrawWrite();
    }

    public void Grap()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found");
            return;
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = (mousePos - _transform.position).normalized;
        // マウス方向へレイを飛ばして接続可能な場所を探す
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, direction, _config.MaxGrappleDistance, _config.GrappleLayer);

        if (hit.collider == null)
            return;
        _joint.enabled = true;
        _lineRenderer.enabled = true;
        // ワイヤーの接続先座標を設定
        _joint.connectedAnchor = hit.point;
        // 距離を自動設定しない
        _joint.autoConfigureDistance = false;
        // 現在位置と接続先の距離をロープの長さにする
        _joint.distance = Vector2.Distance(_transform.position, hit.point);
        // バネの強さ
        _joint.frequency = _config.GrappleFrequency;
        // 揺れの減衰量
        _joint.dampingRatio = _config.DampingRatio;
    }

    public void Release()
    {
        _joint.enabled = false;
        _lineRenderer.enabled = false;
    }

    private void DrawWrite()
    {
        if (!_joint.enabled)
            return;
        _lineRenderer.SetPosition(0, _transform.position);
        _lineRenderer.SetPosition(1, _joint.connectedAnchor);
    }
}
