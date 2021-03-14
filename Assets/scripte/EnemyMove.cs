using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 敵を動かすクラス
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    private NavMeshAgent _agent;
    private EnemyStatus _status;
    private RaycastHit[] raycastHits = new RaycastHit[10];

    [SerializeField]

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
    }

    /// <summary>
    /// 衝突判定を受け取るメソッド
    /// </summary>
    /// <param name="collider"></param>
    public void OnDetectObject(Collider collider) {
        if (!_status.IsMovable) {
            _agent.isStopped = true;
            return;
        }
        if (collider.CompareTag("Player")) {
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;
          
            Ray ray = new Ray(transform.position, positionDiff);
          //  Debug.DrawRay(ray.origin, ray.direction * distance, Color.green, 2, false);
           
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance, raycastLayerMask);

            //Debug.Log("hitCount:"+hitCount);

            if (hitCount == 0)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else {
                _agent.isStopped = true;
            }
        }
    }
}
