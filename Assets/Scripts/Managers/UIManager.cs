using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{   
    public static UIManager i;
    [SerializeField] private TMP_Text moneyText;

    void Awake()
    {
        if(i != null){
            Debug.Log("Singleton error");
            return;
        }
        
        i = this;
    }
    public void UpdateMoneyUI(int _money){
        moneyText.text = _money.ToString();
    }
}
