using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaterKill : MonoBehaviour
{ void OnCollisionEnter2D(Collision2D collision)
    {
        var baseInd = collision.gameObject.gameObject.GetComponent<BaseIndividuum>();
        if (baseInd != null)
            baseInd.Kill();
    }
}