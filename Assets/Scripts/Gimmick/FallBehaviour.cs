using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBehaviour : MonoBehaviour
{
    public int PlayerLayer = 8;
    public float PushForce = 2.0f;

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Found something");
        if(other.gameObject.layer == PlayerLayer) {
            Debug.Log("Found player");
            var rigid = other.gameObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.left * PushForce, ForceMode2D.Force);
            // todo: play push sound
        }
    }
}
