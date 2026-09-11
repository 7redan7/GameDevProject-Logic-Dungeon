using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openedSprite;
    private Collider2D doorCollider;

    [SerializeField] private List<Key> connectedKeys;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        Player.PlayerActionDone += UpdateDoor;
    }

    void OnDisable()
    {
        Player.PlayerActionDone -= UpdateDoor;
    }

    public void UpdateDoor()
    {
        bool isOpen = true;
        foreach (Key key in connectedKeys)
        {
            if (!key.Evaluate())
            {
                isOpen = false;
                break;
            }
        }

        if(isOpen){
            spriteRenderer.sprite = openedSprite;
        }
        else
        {
            spriteRenderer.sprite=closedSprite;
        }
        doorCollider.enabled = !isOpen;
    }
}
