using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Scene3 : MonoBehaviour
{
    // private Rigidbody2D rigid;
    private void Awake()
    {
          // rigid = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "slime")
        {
            this.transform.DOMoveY( -14f, 1.2f);
        }
    }
}
