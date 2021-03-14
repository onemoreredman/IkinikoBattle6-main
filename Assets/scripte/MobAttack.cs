using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃のクラス
/// </summary>
[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

 
    /// <summary>
    /// 状態コンポーネント設置
    /// </summary>
    void Start()
    {
        _status = GetComponent<MobStatus>(); 
    }

    /// <summary>
    /// 攻撃可能なら攻撃するメソッド
    /// </summary>
    public void AttackIfPossible() {
        if (!_status.IsAttackable) return;
        _status.GoToAttackStateIfPossible();
    }

    /// <summary>
    /// 攻撃対象が攻撃範囲に入ったときのメソッド
    /// </summary>
    /// <param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider) {
        AttackIfPossible();
    }

    /// <summary>
    /// 攻撃開始時のメソッド
    /// </summary>
    public void OnAttackStart() {
        attackCollider.enabled = true;
    }

    /// <summary>
    /// attackColliderが攻撃対象にHITしたときのメソッド
    /// </summary>
    /// <param name="collider"></param>
    public void OnHitAttack(Collider collider) {
        var targetMob = collider.GetComponent<MobStatus>();

        if (null == targetMob) return;

        targetMob.Damage(1);
    }

    /// <summary>
    /// 攻撃終了時に呼ばれるメソッド
    /// </summary>
    public void OnAttackFinished() {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());

    }

    private IEnumerator CooldownCoroutine()
    {  
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }    
   
}
