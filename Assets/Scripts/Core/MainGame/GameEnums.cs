namespace MANA.Enums {
    
    /// <summary>
    /// 이 게임의 오브젝트들의 종류
    /// </summary>
    public enum ObjectKind : byte {
        
        Player,
        NPC, Enemy, Boss,
        NONE = 99
    }

    /// <summary>
    /// 플레이어의 상태 종류
    /// </summary>
    public enum PlayerState : byte {
        
        Idle,
        Walk, Run, Talk,
        Attack,
        Dead,
        NONE = 99
    }

    /// <summary>
    /// AI의 상태 종류
    /// </summary>
    public enum AIState : byte {
    
        Idle,
        Walk,
        Attack,
        Dead,
        NONE = 99
    }
}