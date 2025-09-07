using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = "Jump";
    private const int Attack = 0;

    public bool IsAttack { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        if (Input.GetButtonDown(Jump))
        {
            IsJump = true;
        }

        if (Input.GetMouseButtonDown(Attack))
        {
            IsAttack = true;
        }
    }

    public bool GetIsJump()
    {
        bool value = IsJump;
        IsJump = false;
        return value;
    }

    public bool GetIsAttack()
    {
        bool value = IsAttack;
        IsAttack = false;
        return value;
    }
}
