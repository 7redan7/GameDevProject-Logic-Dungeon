using System;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[RequireComponent(typeof(Collider2D))]

public class ObjectWithMovementCollision : MonoBehaviour
{
    [SerializeField] private bool canMove;

    private void Move(Vector3 direction)
    {
        this.transform.position+=direction;
        Physics2D.SyncTransforms();
    }

    public bool CheckAndMove(Vector3 direction)
    {
        if (!canMove)
        {
            return false;
        }

        Collider2D col = Physics2D.OverlapPoint(this.transform.position + direction);
        if (col != null && col.TryGetComponent<ObjectWithMovementCollision>(out ObjectWithMovementCollision other))
        {
            if(other.CheckAndMove(direction))
            {
                this.Move(direction);
                return true;
            }
            return false;
        }
        this.Move(direction);
        return true;
    }
}
