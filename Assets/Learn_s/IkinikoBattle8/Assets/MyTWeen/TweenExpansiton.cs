using UnityEngine;
using UnityEngine.Events;

namespace MyTWeenLib
{
    /// <summary>
    /// Tweenアニメーションを実現する拡張メソッドを実装したクラス
    /// </summary>
    static class TweenExpansion
    {
        /// <summary>
        /// 指示された時間で次の場所に移動するアニメーション
        /// </summary>
        /// <param name="startTrans">移動前の位置</param>
        /// <param name="endPos">移動後の位置</param>
        /// <param name="time">移動にかける時間（秒）</param>
        /// <returns>移動後のTransform情報</returns>
        public static Transform MoveTo(this Transform startTrans, Vector3 endPos, float time)
        {
            Debug.Log($"{startTrans.name} : MoveToメソッドの登録開始");

            MoveTWeen moveTWeen = GetMoveTWeenComponent(startTrans);

            moveTWeen.MoveObj(endPos, time);

            Debug.Log($"{startTrans.name} : MoveToメソッドの登録終了");

            return startTrans;
        }

        /// <summary>
        /// 一連のアニメーションの終了後、イベントバンドラーを起動
        /// </summary>
        /// <param name="trans">イベントを発行するオブジェクトのTransform</param>
        /// <param name="action">移動チェーン終了後に実行したいイベントハンドラ</param>
        /// <returns>移動後のTransform情報</returns>
        public static Transform Complete(this Transform trans, UnityAction action)
        {
            var moveTWeen = GetMoveTWeenComponent(trans);

            moveTWeen.CompleteAction.AddListener(action);

            return trans;
        }

        /// <summary>
        /// TWeen移動スクリプト（コンポーネント）の取得
        /// </summary>
        /// <param name="trans">イベントを発行するオブジェクトのTransform</param>
        /// <returns></returns>
        static MoveTWeen GetMoveTWeenComponent(Transform trans)
        {
            return trans.GetComponent<MoveTWeen>()
                    ?? trans.gameObject.AddComponent<MoveTWeen>();
        }
    }
}