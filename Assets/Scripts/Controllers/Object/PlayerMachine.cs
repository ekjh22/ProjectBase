using System;
using System.Collections.Generic;
using UnityEngine;
using MANA.Enums;
using UDBase.Utils;
using System.Collections;
using UDBase.Controllers.LogSystem;
using Zenject;

namespace UDBase.Controllers.ObjectSystem {

    public class PlayerMachine : MonoBehaviour, IObject, ILogContext
    {
        [Inject]
        ILog _log;

        public string Name { get; private set; }
        public ObjectKind Kind { get; private set; }

        /// <summary>
        /// 플레이어의 기본정보
        /// </summary>
        [Serializable]
        public class Stats {

            /// <summary>
            /// 현재 체력
            /// </summary>
            public float CurHP { get; set; }

            /// <summary>
            /// 최대 체력
            /// </summary>
            public float MaxHP { get; set; }

            /// <summary>
            /// 현재 방어력
            /// </summary>
            public int Armor { get; set; }

            /// <summary>
            /// 공격 속도
            /// </summary>
            public float AttackSpeed { get; set; }

            /// <summary>
            /// 이동 속도
            /// </summary>
            public float MoveSpeed { get; set; }

            public PlayerState State { get; set; }
        }
        public Stats                          myStats { get; set; }
               Dictionary<string, KeySetting> playerKeys;

        public bool IsDead() {
            return myStats.CurHP <= 0;
        }

        public void Kill() {
            myStats.CurHP = 0;
        }

        protected virtual void Start() {

            PlayerSetting(_log);
            StartFSM();
        }

        protected virtual void Update() {

            if (IsDead())
                myStats.State = PlayerState.Dead;
        }

        /// <summary>
        /// 플레이어 셋팅하는 함수
        /// </summary>
        protected virtual void PlayerSetting(ILog log) {

            Name = gameObject.name;     // 이름은 나중에 바꿔도 됨
            Kind = ObjectKind.Player;

            myStats = new Stats();
        }

        void StartFSM() {

            myStats.State = PlayerState.Idle;
            StartCoroutine(myStats.State.ToString());
        }

        void ChanageState() {

            if (myStats.State != PlayerState.Dead)
                StartCoroutine(myStats.State.ToString());
            else
                DeadEvent();
        }

        IEnumerator Idle() {

            while (myStats.State == PlayerState.Idle)
            {
                IdleEvent();
                yield return null;
            }
            //ChanageState();
        }

        IEnumerator Walk() {

            while (myStats.State == PlayerState.Walk)
            {
                WalkEvent();
                yield return null;
            }
            ChanageState();
        }

        IEnumerator Run() {

            while (myStats.State == PlayerState.Run)
            {
                RunEvent();
                yield return null;
            }
            ChanageState();
        }

        IEnumerator Talk() {

            while (myStats.State == PlayerState.Talk)
            {
                yield return null;
            }
            ChanageState();
        }

        IEnumerator Attack() {

            while (myStats.State == PlayerState.Attack)
            {
                AttackEvent();
                yield return null;
            }
            ChanageState();
        }

        /// <summary>
        /// 가만히 있을 때 실행하는 함수
        /// </summary>
        protected virtual void IdleEvent() {

        }

        /// <summary>
        /// 걷고 있을 때 실행하는 함수
        /// </summary>
        protected virtual void WalkEvent() {

        }

        /// <summary>
        /// 달리고 있을 때 실행하는 함수
        /// </summary>
        protected virtual void RunEvent() {

        }

        /// <summary>
        /// 때릴 때 실행하는 함수
        /// </summary>
        protected virtual void AttackEvent() {

        }

        /// <summary>
        /// 죽었을 때 실행하는 함수
        /// </summary>
        protected virtual void DeadEvent() {

        }
    }
}