using System;
using UnityEngine;

[Serializable]
// 商品クラスをシリアライズ
public class Product
{
    // 商品名
    public string Name;

    // 賞味期限
    public string Expiry;

    // 大きさの種類
    public string[] Sizes;
}
public class sample : MonoBehaviour
{
    [SerializeField]
    // 商品のインスタンスをインスペクターに表示させます
    Product product;

    

    string jsonString;

    void Start()
    {
        // 名称
        product.Name = "Apple";

        // 賞味期限
        product.Expiry = new DateTime(2020, 1, 28).ToShortDateString();

        // 大きさの種類
        product.Sizes = new string[] { "Small", "Big" };

        // ToJsonメソッドの第２引数は、見やすくフォーマットするスイッチです
        jsonString = JsonUtility.ToJson(product, true);

        // 画面に出力
        Debug.Log(jsonString);

        // ファイルに保存
        PlayerPrefs.SetString("Product", jsonString);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 保存されたJSON文字列を読み取り
            string loadProductString = PlayerPrefs.GetString("Product");

            // JSON文字列からオブジェクトを復元
            Product loadProductInstance = JsonUtility.FromJson<Product>(loadProductString);

            // 復元の確認
            Debug.Log($"商品名：{loadProductInstance.Name}");
            Debug.Log($"賞味期限：{loadProductInstance.Expiry}");

            foreach (var size in loadProductInstance.Sizes)
            {
                Debug.Log($"大きさの種類：{size}");
            }
        }
    }
}