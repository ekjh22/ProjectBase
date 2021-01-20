using DG.Tweening;

namespace UDBase.Tweens {
	/// <summary>
	/// 헬퍼 메소드 DG.Tween/Sequence 사용해서 구현
	/// </summary>
	public static class TweenHelper {

		/// <summary>
		/// 지정된 시퀀스를 재설정하고 새 시퀀스로 교체
		/// </summary>
		public static Sequence Replace(Sequence seq, bool complete = false) {
			if( seq != null ) {
				seq = Reset(seq, complete);
			}
			return DOTween.Sequence();
		}

		/// <summary>
		/// 지정된 시퀀스 재설정
		/// </summary>
		public static Sequence Reset(Sequence seq, bool complete = false) {
			if( seq != null ) {
				if( complete ) {
					seq.Complete();
				}
				seq.Kill();
				seq = null;
			}
			return seq;
		}
	}
}
