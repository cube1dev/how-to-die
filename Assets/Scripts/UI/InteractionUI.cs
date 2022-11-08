using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [System.NonSerialized] public string UseMessage = "Use the ladder";
    [System.NonSerialized] public string Key = "E";

    [SerializeField] private Text use;

    [SerializeField] private Text key;

    void Update() {
        use.text = UseMessage;
        key.text = Key;
    }
}
