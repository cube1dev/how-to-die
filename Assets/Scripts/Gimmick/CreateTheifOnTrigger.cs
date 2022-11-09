using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTheifOnTrigger : MonoBehaviour
{
    public GameObject TheifPrefab;
    public Transform TheifLocation;
    public GameObject PoliceCarPrefab;
    public Transform PoliceCarLocation;

    private bool alreadySpawned = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8) {
            CharacterMovement.Singleton.IsMovable = false;
            StartCoroutine(StartGimmick());
        }
    }

    IEnumerator StartGimmick() {
        Instantiate(TheifPrefab, TheifLocation.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(PoliceCarPrefab, PoliceCarLocation.position, Quaternion.identity);
    }
}
