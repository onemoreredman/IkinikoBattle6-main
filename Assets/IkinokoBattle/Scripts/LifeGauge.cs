using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private RectTransform _parentRectTransform;
    private Camera _camera;
    private MobStatus _status;

    private void Update()
    {
        

            Refresh();
        
    }

    /// <summary>
    /// ゲージを初期化
    /// </summary>
    /// <param name="parentRectTransform"></param>
    /// <param name="camera"></param>
    /// <param name="status"></param>
    public void Initialize(RectTransform parentRectTransform,Camera camera, MobStatus status)
    {

        _parentRectTransform = parentRectTransform;
        _camera = camera;
        _status = status;
        Refresh();
    }

    /// <summary>
    /// ゲージを更新する
    /// </summary>
    private void Refresh()
    {
        if (_status != null) { 
        fillImage.fillAmount = _status.Life / _status.LifeMax;

        var screenPoint = _camera.WorldToScreenPoint(_status.transform.position);
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, screenPoint, null, out localPoint);
        transform.localPosition = localPoint + new Vector2(0, 80);
    }
    }
}
