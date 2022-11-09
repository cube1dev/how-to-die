using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoliceCar : MonoBehaviour
{
    public GameObject PoliceOfficerPrefab;
    public Transform ToTransform;
    public Transform PoliceOfficerSpawn;

    void Start() {
        StartCoroutine(PoliceCarGimmick());
    }

    IEnumerator PoliceCarGimmick() {
        transform.DOMove(ToTransform.position, 2.0f);
        yield return new WaitForSeconds(2.0f);
        Instantiate(PoliceOfficerPrefab, PoliceOfficerSpawn.position, Quaternion.identity);
    }
}
