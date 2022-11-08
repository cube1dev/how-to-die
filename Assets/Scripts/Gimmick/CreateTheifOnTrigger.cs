using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTheifOnTrigger : MonoBehaviour
{
    public GameObject TheifPrefab;
    public Transform TheifLocation;

    private bool alreadySpawned = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
            CharacterMovement.Singleton.IsMovable = false;
            Instantiate(TheifPrefab, TheifLocation.position, Quaternion.identity);
        }
    }
}
