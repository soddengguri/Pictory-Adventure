using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField]
    private string title;

    public string Mytitle
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }
}
