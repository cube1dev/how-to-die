using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMatDetector : MonoBehaviour
{
    private bool alreadyRun = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(!alreadyRun && coll.gameObject.layer == 11) {
            PushGimmick.Singleton.OnPlayerDetected();
            alreadyRun = true;
        }
    }
}
