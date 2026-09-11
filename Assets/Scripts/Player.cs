using UnityEngine;
using System;

[RequireComponent(typeof(ObjectWithMovementCollision))]

public class Player : MonoBehaviour
{
    public static event Action PlayerActionDone;

    [SerializeField] private float resetHoldSeconds = 1f;

    private ObjectWithMovementCollision objectWithMovementCollision;
    private float resetHoldTimer;

    void Awake()
    {
        objectWithMovementCollision = GetComponent<ObjectWithMovementCollision>();
    }

    void Update()
    {
        if (TruthTableMenu.GameIsPaused)
        {
            return;
        }

        if (CheckResetHold())
        {
            return;
        }

        Vector3 direction = GetDirection();
        if (direction != Vector3.zero)
        {
            objectWithMovementCollision.CheckAndMove(direction);
            PlayerActionDone?.Invoke();
        }
    }

    bool CheckResetHold()
    {
        if (!Input.GetKey(KeyCode.R))
        {
            resetHoldTimer = 0f;
            return false;
        }

        resetHoldTimer += Time.unscaledDeltaTime;

        if (resetHoldTimer < resetHoldSeconds)
        {
            return false;
        }

        resetHoldTimer = 0f;
        SceneLoader.ReloadCurrentScene();
        return true;
    }

    Vector3 GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return Vector3.right;
        }

        return Vector3.zero;
    }
}

