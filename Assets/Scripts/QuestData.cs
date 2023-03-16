using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName; //퀘스트 명
    public int[] NpcId; // 퀘스트에 관련된 NPC id 모음


    //빈 생성자
    public QuestData() { }

    //생성자
    public QuestData(string name, int[] npcid)
    {
        questName = name;
        NpcId = npcid;
    }
}
