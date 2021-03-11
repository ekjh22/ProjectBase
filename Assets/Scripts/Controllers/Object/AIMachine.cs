using System;
using System.Collections;
using UnityEngine;
using MANA.Enums;
using UDBase.Utils;
using Zenject;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ObjectSystem {

    public class AIMachine : MonoBehaviour, IObject, ILogContext
    {
        [Inject]
        ILog _log;

        public string Name { get; private set; }
        public ObjectKind Kind { get; private set; }

        /// <summary>
        /// AI의 기본정보
        /// </summary>
        [Serializable]
        public class Stats
        {

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

            /// <summary>
            /// 대화 거리
            /// </summary>
            public float Radius { get; set; }

            public AIState State { get; set; }
        }
        public Stats myStats { get; set; }
        KeySetting AIKey;

        public bool IsDead()
        {
            return myStats.CurHP <= 0;
        }

        public void Kill()
        {
            myStats.CurHP = 0;
        }

        protected virtual void Start()
        {
            AISetting(_log);
            StartFSM();
        }

        protected virtual void Update()
        {

            AIKey?.Update();
        }

        /// <summary>
        /// AI 셋팅하는 함수
        /// </summary>
        protected virtual void AISetting(ILog log)
        {
            Name = gameObject.name;     // 이름은 나중에 바꿔도 됨

            AIKey = new KeySetting(KeyCode.Q, Talk);
        }

        void StartFSM() {

            myStats = new Stats();

            myStats.State = AIState.Idle;
            StartCoroutine(myStats.State.ToString());
        }

        void ChanageState()
        {

            if (myStats.State != AIState.Dead)
                StartCoroutine(myStats.State.ToString());
            else
                DeadEvent();
        }

        IEnumerator Idle()
        {

            while (myStats.State == AIState.Idle)
            {
                IdleEvent();
                yield return null;
            }
            ChanageState();
        }

        IEnumerator Walk()
        {

            while (myStats.State == AIState.Walk)
            {
                IdleEvent();
                yield return null;
            }
            ChanageState();
        }

        IEnumerator Attack()
        {

            while (myStats.State == AIState.Attack)
            {
                IdleEvent();
                yield return null;
            }
            ChanageState();
        }

        void Talk()
        {

            if (Kind == ObjectKind.NPC)
            {

                GameObject obj = GameObject.FindGameObjectWithTag("Player");
                if (obj != null)
                {

                    if (Vector2.Distance(gameObject.transform.position, obj.transform.position) <= myStats.Radius)
                    {

                        obj.GetComponent<PlayerMachine>().myStats.State = PlayerState.Talk;
                        Callback();
                    }
                }
            }
        }

        /// <summary>
        /// 가만히 있을 때 실행하는 함수
        /// </summary>
        protected virtual void IdleEvent()
        {

        }

        /// <summary>
        /// 걷고 있을 때 실행하는 함수
        /// </summary>
        protected virtual void WalkEvent()
        {

        }

        /// <summary>
        /// 해당 AI와 대화를 할 때 실행하는 함수
        /// </summary>
        protected virtual void Callback()
        {

        }

        /// <summary>
        /// 때리고 있을 때 실행하는 함수
        /// </summary>
        protected virtual void AttackEvent()
        {

        }

        /// <summary>
        /// 죽을 때 실행하는 함수
        /// </summary>
        protected virtual void DeadEvent()
        {

        }
    }
}