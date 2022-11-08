using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheat : MonoBehaviour
{
    private PlayerAction playerAction;

    public Transform Gimmick8;

    void Awake() {
        playerAction = new PlayerAction();
    }

    void OnEnable() {
        playerAction.Enable();

        playerAction.Cheats.Gimmick8.performed += (ctx) => {
            transform.position = Gimmick8.position;
        };
    }
}
