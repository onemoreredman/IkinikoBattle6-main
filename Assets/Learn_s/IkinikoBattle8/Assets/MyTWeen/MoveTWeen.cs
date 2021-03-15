using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyTWeenLib
{
    /// <summary>
    /// Tweenアニメーションを実行するクラス
    /// </summary>
    public class MoveTWeen : MonoBehaviour
    {
        readonly Queue<IEnumerator> moveTWeenQueue = new Queue<IEnumerator>();

        public UnityEvent CompleteAction = new UnityEvent();

        /// <summary>
        /// スタート時点で実行されるコルーチン
        /// キューにデータがある場合、順番に実行されるようにする
        /// キューのメソッドが完了するのを待って、次のキューのメソッドを実行
        /// コルーチンで、メソッド完了待ち
        /// </summary>
        /// <returns>イテレータ（コルーチンで必要）</returns>
        IEnumerator Start()
        {
            Debug.Log($"{gameObject.name}： MoveLinearメソッド開始");

            while (true)
            {
                switch (moveTWeenQueue.Count)
                {
                    case 0:
                        if (CompleteAction != null)
                        {
                            CompleteAction.Invoke();
                            CompleteAction.RemoveAllListeners();
                        }
                        yield return null;
                        break;

                    default:
                        Debug.Log($"{gameObject.name}： TWeen 開始");

                        yield return StartCoroutine(moveTWeenQueue.Dequeue());

                        Debug.Log($"{gameObject.name}： Tween 終了");
                        break;
                }
            }
        }

        /// <summary>
        /// 実行待ちキューにコルーチンをセット
        /// </summary>
        /// <param name="endPos">到達ポシション</param>
        /// <param name="moveTime">到達するまでの時間</param>
        public void MoveObj(Vector3 endPos, float moveTime)
        {
            moveTWeenQueue.Enqueue(MoveLinear(endPos, moveTime));
        }

        /// <summary>
        /// 移動を実施する
        /// コルーチンで、移動時間から１フレームで移動する教理を計算して、少しずつ移動するようにしている
        /// </summary>
        /// <param name="endPos">到達ポシション</param>
        /// <param name="moveTime">到達するまでの時間</param>
        /// <returns>イテレーター（コルーチンで必要）</returns>
        IEnumerator MoveLinear(Vector3 endPos, float movetTime)
        {
            var deltaMovePos = (endPos - transform.position) * Time.deltaTime / movetTime;

            float nextDiffPosSize;
            float diffPosSize;

            do
            {
                transform.position += deltaMovePos;

                diffPosSize = (endPos - transform.position).magnitude;

                nextDiffPosSize = (endPos - (transform.position + deltaMovePos)).magnitude;

                yield return null;

            } while (diffPosSize - nextDiffPosSize > 0);

            transform.position = endPos;

            Debug.Log($"{gameObject.name}： TWeen終了位置：{endPos}");
        }
    }
}