using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵の状態管理スクリプト
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    private NavMeshAgent _agent;

    protected override void Start()
    {
        base.Start();
        _agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// NavMeshAgentのvelocityで移動速度のベクトルを取得する
    /// </summary>
    private void Update() {

            }

    protected override void OnDie() {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
    }

    /// <summary>
    /// 消滅コルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyCoroutine() {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    // Update is called once per frame
   
}
