using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public bool IsMovable = true;

    public static CharacterMovement Singleton;

    private PlayerAction playerAction;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    public float Speed = 3.0f;

    float GetMoveAxis() {
        return playerAction.PlayerActions.Move.ReadValue<float>();
    }

    void Awake() {
        Singleton = this;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAction = new PlayerAction();

        playerAction.PlayerActions.Move.canceled += (ctx) => {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        };
        playerAction.PlayerActions.Move.performed += (ctx) => {
            if(!IsMovable)
                return;
            var axis = GetMoveAxis();
            if((int)axis == 1) {
                spriteRenderer.flipX = false;
            } else if((int)axis == -1) {
                spriteRenderer.flipX = true;
            }
        };
    }

    void OnEnable() {
        playerAction.Enable();
    }

    void OnDisable() {
        playerAction.Disable();
    }

    void FixedUpdate() {
        if(!IsMovable) return;

        var axis = GetMoveAxis();

        rigid.AddForce(Vector2.right * axis, ForceMode2D.Impulse);

        if(rigid.velocity.x > Speed) {
            rigid.velocity = new Vector2(Speed, rigid.velocity.y);
        } else if(rigid.velocity.x < Speed * (-1)) {
            rigid.velocity = new Vector2(Speed * (-1), rigid.velocity.y);
        }
    }
}
