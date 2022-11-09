using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnableWhenExit : MonoBehaviour
{
    public Collider2D coll;
    public SpriteRenderer spriteRenderer;

    void OnTriggerExit2D(Collider2D trigger) {
        if(trigger.gameObject.layer != 11) return;
        
        coll.enabled = true;
        spriteRenderer.DOFade(1.0f, 0.0f);
    }
}
