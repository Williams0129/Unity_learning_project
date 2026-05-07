using UnityEngine;
using UnityEngine.UI;

public class MyScreenLog : MonoBehaviour
{
    // 在 Inspector 視窗中關聯要顯示文字的 UI Text 元件
    public Text logText;

    // 宣告一個靜態變數 Instance，讓其他腳本不用 GetComponent 就能直接呼叫 MyScreenLog.Log()
    // private set 表示這個變數只能在類別內部修改，外部只能讀取
    public static MyScreenLog Instance { get; private set; }

    // 當腳本啟動時執行的第一個生命週期函數
    void Awake()
    {
        // 如果目前還沒有 Instance，就把自己設定為 Instance
        if (!Instance)
            Instance = this;
    }

    // 當遊戲物件被啟動後，第一幀更新前執行
    private void Start()
    {
        // 遊戲開始時先清空 UI Text 上的文字，避免看到範例字樣
        if (logText)
            logText.text = "";
    }

    // 內部的實作方法：負責處理字串並更新到 UI 畫面上
    private void _log(string msg)
    {
        if (logText)
            // 將新訊息加在原本的文字後面，並加上 \n (換行符號)
            logText.text += msg + "\n";
    }

    // 靜態方法：提供給外部腳本呼叫的「單一入口」
    // 使用方式：MyScreenLog.Log("要顯示的訊息");
    public static void Log(string msg)
    {
        // 如果場景中有這個腳本的實體(Instance)，就執行 UI 更新
        if (Instance)
            Instance._log(msg);

        // 同時也在 Unity 底層的 Console 視窗印出訊息，方便雙重檢查
        Debug.Log(msg);
    }
}