using UnityEngine;
using System.Collections.Generic;

public enum SideType { None, Input, Output }

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ObjectWithMovementCollision))]

public abstract class LogicGate : MonoBehaviour
{
    [SerializeField] protected Sprite offSprite;
    [SerializeField] protected Sprite onSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] protected SideType left  = SideType.None;
    [SerializeField] protected SideType right = SideType.None;
    [SerializeField] protected SideType up    = SideType.None;
    [SerializeField] protected SideType down  = SideType.None;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnOnOff();
    }

    void OnEnable()
    {
        Player.PlayerActionDone += TurnOnOff;
    }

    void OnDisable()
    {
        Player.PlayerActionDone -= TurnOnOff;
    }

    private void TurnOnOff()
    {
        if (Evaluate())
        {
            spriteRenderer.sprite = onSprite;
        }
        else
        {
            spriteRenderer.sprite = offSprite;
        }
    }
    public abstract bool Evaluate();
    public List<Vector3> GetSideType(SideType type)
    {
        List<Vector3> types = new List<Vector3>();
        if (left == type)
        {
            types.Add(new Vector3(-1, 0, 0));
        }
        if (right == type)
        {
            types.Add(new Vector3(1, 0, 0));
        }
        if (up == type)
        {
            types.Add(new Vector3(0, 1, 0));
        }
        if (down == type)
        {
            types.Add(new Vector3(0, -1, 0));
        }
        return types;
    }
}
