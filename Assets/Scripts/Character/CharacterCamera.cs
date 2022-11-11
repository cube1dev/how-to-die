using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour {
    public GameObject Target;
    public float LerpSpeed = 2f;
    public float CameraZ = -10;

    void FixedUpdate() {
        var targetPos = new Vector3(Target.transform.localPosition.x, Target.transform.localPosition.y, CameraZ);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * LerpSpeed);
    }
}
