using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    public static QuestLog instance;

    public Text questDescription;
    public Text questName;
    public Transform questHolder;
    public GameObject questButtonPrefab;

    private void Awake()
    {
        if (instance != null) instance = this;
    }

    public void UpdateQuestUI(QuestBase newQuest)
    {
        questName.text = newQuest.questName;
        questDescription.text = newQuest.questDescription;

    }

    public void AddQuestToLog(QuestBase newQuest)
    {
        Instantiate(questButtonPrefab, questHolder);
    }
}
