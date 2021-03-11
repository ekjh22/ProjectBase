using System;
using UnityEngine;

namespace UDBase.Utils {

    /// <summary>
    /// 키 셋팅 클래스
    /// </summary>
    public class KeySetting
    {

        /// <summary>
        /// 키 코드 값
        /// </summary>
        public KeyCode KeyValue { get; set; }
        
        /// <summary>
        /// 해당 키 실행 시 실행할 콜백 값
        /// </summary>
        public Action  Func     { get; set; }
        
        public KeySetting (KeyCode key, Action func) {
            KeyValue = key;
            Func     = func;
        }

        /// <summary>
        /// 현재 키 값을 눌렀는지 확인하는 함수
        /// </summary>
        public bool Update() {
            
            if (Input.GetKeyDown(KeyValue)) {

                Func();
                return true;
            }
            return false;
        }
    }
}