using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadTime : MonoBehaviour
{
    public int LevelId;
    public TextMeshProUGUI BestTimeText;

    private void Start()
    {
        BestTimeText.text = PlayerPrefs.GetFloat("Level" + LevelId, 9999).ToString();
    }
}
