using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.ObjectSystem;
using UDBase.Controllers.LogSystem;
using MANA.Enums;
using UDBase.Utils;

public class Player : PlayerMachine
{
    ULogger _log;

    [SerializeField] private GameObject[] attackColiders;
    [SerializeField] private Vector2      _attackDir = Vector2.zero;
    [SerializeField] private float        _jumpForce = 0f;

    protected sealed override void PlayerSetting(ILog log)
    {
        _log = log.CreateLogger(this);

    }

    protected sealed override void IdleEvent() {

        base.IdleEvent();
    }

    protected sealed override void WalkEvent() {

        base.WalkEvent();
    
        // 움직이는 로직
    }

    protected sealed override void RunEvent() {

        base.RunEvent();

        // 움직이는 로직
    }

    protected sealed override void JumpEvent() {

        base.JumpEvent();

        // 점프하는 로직
        if (!MyStats.IsJump) {

            MyStats.IsJump = true;
            StartCoroutine("GetJumpForce");
        }
    }

    protected sealed override void TalkEvent() {

        base.TalkEvent();

    }

    protected sealed override void AttackEvent() {

        base.AttackEvent();

    }

    protected sealed override void SpecialAttackEvent() {

        base.SpecialAttackEvent();

        if (MyStats.IsJump) {

            MyStats.State = PlayerState.Idle;
            return;
        }
    }

    protected sealed override void DeadEvent() {
        base.DeadEvent();
    }

    void Combo() {

        // 방향 공격
        if (MyStats.State == PlayerState.Attack) {

            // ...
            _attackDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {

            }

            // 하단 공격
            if (Input.GetKeyDown(KeyCode.DownArrow)) {

            }
        }

        // 하단 이동
        if (MyStats.State == PlayerState.Jump) {

            if (Input.GetKeyDown(KeyCode.DownArrow)) {

            }
        }
    }

    void AnimFrameStart() {
    
    }

    void AnimFrameUpdate() {

        if (MyStats.State == PlayerState.Attack) {

            // 방향에 따른 방향 공격
        }
    }

    void AnimFrameEnd() {

    }

    IEnumerator GetKeyTime(float time = 1f, PlayerState state = PlayerState.NONE) {

        float progress = 0f;

        while (progress <= time) {

            if (Input.anyKeyDown) {

                if (state == PlayerState.Attack || state == PlayerState.SpecialAttack || state == PlayerState.Jump) {
                    
                    Combo();
                    progress = time;
                }
            }
            progress += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator GetJumpForce(float time = 1f) {

        float progress = 0f;

        while (progress <= time) {

            if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                
                if (MyStats.State == PlayerState.Jump) {
                    
                    _jumpForce += MyStats.JumpPower * Time.deltaTime;
                }
            }
            progress += Time.deltaTime;
            yield return null;
        }
        // 점프 로직
        StartCoroutine(GetKeyTime(1f, MyStats.State));
    }
}
