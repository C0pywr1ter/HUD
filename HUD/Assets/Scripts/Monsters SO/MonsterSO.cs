using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Monster Data", menuName = "Monster Data", order = 51)]

public class MonsterSO : ScriptableObject
{
 
    [SerializeField]
    private string monsterName;
    [SerializeField]
    private string monsterDescription;
    [SerializeField]
    private float monsterLevel;
    [SerializeField]
    private float monsterHealth;


 
    public string MonsterName { get {  return monsterName; } }
    public string MonsterDescription { get { return monsterDescription; } }
    public float MonsterLevel { get { return monsterLevel;  } }
    public float MonsterHealth { get { return monsterHealth; } }


}
