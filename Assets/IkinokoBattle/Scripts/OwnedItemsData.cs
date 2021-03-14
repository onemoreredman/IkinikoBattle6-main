using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OwnedItemsData 
{
    /// <summary>
    /// PlayerPrefs保存先キー
    /// </summary>
    private const string PlayerPrefsKey = "OWNED_ITEMS_DATA";
    // Start is called before the first frame update

    /// <summary>
    /// インスタンスを返す
    /// </summary>
    public static OwnedItemsData Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = PlayerPrefs.HasKey(PlayerPrefsKey)
                    ? JsonUtility.FromJson<OwnedItemsData>(PlayerPrefs.GetString(PlayerPrefsKey))
                    : new OwnedItemsData();
            }
            return _instance;
        }
    }

    private static OwnedItemsData _instance;
    /// <summary>
    /// 所持アイテム一覧を取得します
    /// </summary>
    public OwnedItem[] OwnedItems
    {
        get { return ownedItems.ToArray(); }
    }

    /// <summary>
    /// どのアイテムを何個所持しているかのリスト
    /// </summary>
    [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>();

    /// <summary>
    /// コンストラクター（シングルトーンなので中身は見れない）
    /// </summary>
    private OwnedItemsData()
    {

    }

    public void Save() {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefsKey, jsonString);
    }

    /// <summary>
    /// アイテム追加
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    public void Add(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);
        if (null == item)
        {
            item = new OwnedItem(type);
            ownedItems.Add(item);
        }
        item.Add(number);
    }

    /// <summary>
    /// アイテムを消費する
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    public void Use(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);
        if (null == item || item.Number < number)
        {
            throw new Exception("アイテムが足りません");
        }
        item.Use(number);
    }

    /// <summary>
    /// 対象の種類のアイテムデータを取得
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public OwnedItem GetItem(Item.ItemType type) {
        return ownedItems.FirstOrDefault(x => x.Type == type);
    }

    [Serializable]
    public class OwnedItem
    {
        public Item.ItemType Type
        {
            get { return type; }
        }

        public int Number
        {
            get { return number; }
        }
    

    /// <summary>
    /// アイテムの種類
    /// </summary>
    [SerializeField] private Item.ItemType type;

    /// <summary>
    /// 所持個数
    /// </summary>
    [SerializeField] private int number;

    public OwnedItem(Item.ItemType type) {
        this.type = type;
    }

    public void Add(int number = 1)
    {
        this.number += number;
    }

    public void Use(int number = 1)
    {
        this.number -= number;
    }
}
}