using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverName : MonoBehaviour
{
    Button okBtn;
    public InputField coverNameInput;
    public Text coverNameView;

    private void Start()
    {
        okBtn = this.transform.GetComponent<Button>();
        okBtn.onClick.AddListener(LoadName);
    }

    public void LoadName()
    {
        coverNameView.text = coverNameInput.text;
    }
}
