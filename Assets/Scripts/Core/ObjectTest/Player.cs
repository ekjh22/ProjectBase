using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.ObjectSystem;
using UDBase.Controllers.LogSystem;

public class Player : PlayerMachine
{
    ULogger _log;

    protected sealed override void PlayerSetting(ILog log)
    {
        _log = log.CreateLogger(this);
    }

    protected sealed override void IdleEvent()
    {
        base.IdleEvent();
    }

    protected sealed override void WalkEvent()
    {
        base.WalkEvent();
    }

    protected sealed override void RunEvent()
    {
        base.RunEvent();
    }

    protected sealed override void AttackEvent()
    {
        base.AttackEvent();
    }

    protected sealed override void DeadEvent()
    {
        base.DeadEvent();
    }
}
