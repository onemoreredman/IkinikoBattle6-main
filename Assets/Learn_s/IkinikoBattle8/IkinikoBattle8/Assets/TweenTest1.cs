using UnityEngine;
using MyTWeenLib;

public class TweenTest1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"{ gameObject.name}： 移動処理スタート");

            transform.MoveTo(new Vector3(5, 0, 0), 1)
                     .MoveTo(new Vector3(5, 0, 5), 1)
                     .MoveTo(new Vector3(0, 0, 5), 1);

            Debug.Log($"{ gameObject.name}： 移動処理開放。他の処理が実行可能");
        }
    }
}