using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TypeBonus", menuName = "TypeBonus")]
public class ScriptableBonus : ScriptableObject
{
    public int value;
    public string variableAffected;
    public Sprite sprt;
}
