using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallMatPlacer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll) {
        transform.DOMoveX(-2.843f, 1.2f);
    }
}
