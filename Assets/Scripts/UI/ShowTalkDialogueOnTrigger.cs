using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTalkDialogueOnTrigger : MonoBehaviour
{
    public bool Once = false;
    public GameObject TalkPrefab;
    public Transform Canvas;
    public int PlayerLayer = 8;

    private bool triggeredAlready = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == PlayerLayer) {
            if(Once && triggeredAlready)
                return;
            
            Instantiate(TalkPrefab, Canvas);
        }
    }
}
