using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCube : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
