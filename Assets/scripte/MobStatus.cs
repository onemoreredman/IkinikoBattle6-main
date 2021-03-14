using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラの状態を管理する抽象クラス
/// </summary>
public abstract class MobStatus : MonoBehaviour
{
    /// <summary>
    /// 状態の定義
    /// </summary>
    protected enum StateEnum {
        Normal,
        Attack,
        Die
    }

    /// <summary>
    /// 移動可能かどうか
    /// </summary>
    public bool IsMovable => StateEnum.Normal == _state;

    /// <summary>
    /// 攻撃可能かどうか
    /// </summary>
    public bool IsAttackable => StateEnum.Normal == _state;

    /// <summary>
    /// ライフ数の最大値を設定
    /// </summary>
    public float LifeMax => lifeMax;

    /// <summary>
    /// ライフの値を返す
    /// </summary>
    public float Life => _life;

    [SerializeField] private float lifeMax = 2;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    private float _life;

    /// <summary>
    /// ライフを満タン設定
    /// アニメーションの設定
    /// </summary>
    protected virtual void Start() {
        _life = LifeMax;
        _animator = GetComponentInChildren<Animator>();

        LifeGaugeContainer.Instance.Add(this);
    }

    /// <summary>
    /// キャラクターが倒れた時の処理
    /// </summary>
    protected virtual void OnDie() {

        LifeGaugeContainer.Instance.Remove(this);
    }

    /// <summary>
    /// ダメージを受けたときの処理
    /// </summary>
    /// <param name="damage">攻撃力</param>
    public void Damage(int damage) {
        if (_state == StateEnum.Die) return;

        _life -= damage;
        if (_life > 0) return;

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");

        OnDie();
    }

    /// <summary>
    /// 攻撃中の状態に移動するクラス
    /// </summary>
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");

    }

    /// <summary>
    /// Normal状態に変化するクラス
    /// </summary>
    public void GoToNormalStateIfPossible() {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }
    // Update is called once per frame
}

