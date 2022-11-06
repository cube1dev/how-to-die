using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour {
    public GameObject Target;
    public float LerpSpeed = 2f;
    public float CameraZ = -10;

    void FixedUpdate() {
        var targetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * LerpSpeed);
    }
}
