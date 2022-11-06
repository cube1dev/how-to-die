using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionInteraction : MonoBehaviour
{
    public GameObject InteractionPrefab;
    public Transform Canvas;
    public string UseMessage = "Use the ladder";
    public string Key = "E";

    private bool uiDestroyed = true;
    private bool beingStarted = false;
    private GameObject interaction;
    private PlayerAction playerAction;

    void Awake() {
        playerAction = new PlayerAction();
    }

    void OnEnable() {
        playerAction.Enable();

        playerAction.PlayerActions.Interact.performed += (ctx) => {
            if(!uiDestroyed)
                SendMessage("Interact");
        };
    }

    void OnTriggerEnter2D() {
        beingStarted = true;
        interaction = uiDestroyed ? Instantiate(InteractionPrefab, Canvas) : interaction;
        uiDestroyed = false;

        var interUI = interaction.GetComponent<InteractionUI>();
        interUI.Key = Key;
        interUI.UseMessage = UseMessage;

        var rectTransform = interaction.GetComponent<RectTransform>();
        rectTransform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f)
            .OnComplete(() => {
                beingStarted = false;
            });
    }

    void OnTriggerExit2D() {
        var rectTransform = interaction.GetComponent<RectTransform>();
        rectTransform.DOScale(new Vector3(0.0f, 0.0f, 1.0f), 0.5f)
            .OnComplete(() => {
                if(!beingStarted) {
                    uiDestroyed = true;
                    Destroy(interaction);
                }
            });
    }
}
