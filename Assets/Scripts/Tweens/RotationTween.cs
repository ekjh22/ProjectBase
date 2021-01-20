using UnityEngine;
using DG.Tweening;

namespace UDBase.Tweens {
	/// <summary>
	/// 시각적 설정을 사용하여 회전시킬 수 있는 Tween 헬퍼
	/// </summary>
	[AddComponentMenu("UDBase/Tweens/RotationTween")]
	public class RotationTween : MonoBehaviour {

		/// <summary>
		/// 자동 시작 유무
		/// </summary>
		[Tooltip("자동 시작 유무")]
		public bool AutoPlay = true;

		/// <summary>
		/// 종료 회전 값
		/// </summary>
		[Tooltip("종료 회전 값")]
		public Vector3 EndValue = Vector3.zero;

		/// <summary>
		/// 최대 회전 시간
		/// </summary>
		[Tooltip("최대 회전 시간")]
		public float Duration;

		/// <summary>
		/// DOTween 회전 모드
		/// </summary>
		[Tooltip("DOTween 회전 모드")]
		public RotateMode Mode = RotateMode.Fast;

		/// <summary>
		/// 몇번 루프할 것 인가 (-1 = 무제한)
		/// </summary>
		[Tooltip("몇번 루프할 것 인가 (-1 = 무제한)")]
		public int Loops = -1;

		/// <summary>
		/// DOTween 세부적인 모드
		/// </summary>
		[Tooltip("DOTween 세부적인 모드")]
		public Ease Ease = Ease.Unset;

		Sequence _seq;

		void OnEnable() {
			if ( AutoPlay ) {
				StartAnimation();
			}
		}

		void OnDisable() {
			StopAnimation();
		}

		/// <summary>
		/// 현재 매개 변수로 애니메이션 시작
		/// </summary>
		public void StartAnimation() {
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DORotate(EndValue, Duration, Mode));
			_seq.SetLoops(Loops);
			_seq.SetEase(Ease);
		}

		/// <summary>
		/// 애니메이션 중지(시작된 경우)
		/// </summary>
		public void StopAnimation() {
			_seq = TweenHelper.Reset(_seq);
		}

	}
}
