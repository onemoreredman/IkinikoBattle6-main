using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class LifeGaugeContainer : MonoBehaviour
{
    public static LifeGaugeContainer Instance
    {
        get { return _instance; }
    }

    private static LifeGaugeContainer _instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LifeGauge lifeGaugePrefab;

    private RectTransform rectTransform;
    private readonly Dictionary<MobStatus, LifeGauge> _statusLifeBarMap =new Dictionary<MobStatus, LifeGauge>();


    private void Awake() {
    if (null != _instance) throw new Exception("LifeBarContainer instance already exits.");
    _instance = this;
    rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// ライフゲージを追加する
    /// </summary>
    /// <param name="status"></param>
    public void Add(MobStatus status1) {
    var lifeGauge = Instantiate(lifeGaugePrefab, transform);
    lifeGauge.Initialize(rectTransform, mainCamera, status1);
    _statusLifeBarMap.Add(status1, lifeGauge);
    }
    
    /// <summary>
    /// ライフゲージを破棄する
    /// </summary>
    /// <param name="status"></param>
    public void Remove(MobStatus status) {
        Destroy(_statusLifeBarMap[status].gameObject);
        _statusLifeBarMap.Remove(status);
}
}
