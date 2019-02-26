using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCube : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        gameObject.SetActive(false);
    }
}
