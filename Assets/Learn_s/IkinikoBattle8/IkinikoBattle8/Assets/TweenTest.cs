using UnityEngine;
using MyTWeenLib;

public class TweenTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"{ gameObject.name}： 移動処理スタート");

            transform.MoveTo(new Vector3(1, 0, 0), 1)
                     .MoveTo(new Vector3(1, 0, 1), 1)
                     .MoveTo(new Vector3(0, 0, 1), 1)
                     .Complete(() => Debug.Log($"{gameObject.name}： 全てのアニメーションが完了"));

            Debug.Log($"{ gameObject.name}： 移動処理開放。他の処理が実行可能");
        }
    }
}