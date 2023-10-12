using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterSO monsterSO;
    [SerializeField]
    private Image monsterHealthBar;
    [SerializeField]
    private TextMeshProUGUI monsterLevel;
    [SerializeField]
    private TextMeshProUGUI monsterName;
     void Start()
    {
        Debug.Log(monsterSO.MonsterDescription);
        monsterHealthBar.fillAmount = monsterSO.MonsterHealth;
        monsterLevel.text = monsterSO.MonsterLevel.ToString();
        monsterName.text = monsterSO.MonsterName.ToString();

    }
  
}
