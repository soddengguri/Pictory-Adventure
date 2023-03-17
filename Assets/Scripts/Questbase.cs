using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : ScriptableObject
{
    public string questName;
    public string questDescription;

    public int[] CurrentAmount { get; set;}
    public int[] RequiredAmount { get; set;}

    public bool IsCompleted { get; set;}

}
