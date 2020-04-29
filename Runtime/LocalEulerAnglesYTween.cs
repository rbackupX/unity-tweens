using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalEulerAnglesYTween {
    public static Tween<float> TweenLocalRotationY (this Component self, float to, float duration) =>
      self.gameObject.TweenLocalRotationY (to, duration);

    public static Tween<float> TweenLocalRotationY (this GameObject self, float to, float duration) =>
      self.AddComponent<Tween> ().Finalize (duration, to);

    private class Tween : Tween<float> {
      private Quaternion quaternionValueFrom;
      private Quaternion quaternionValueTo;

      public override bool OnInitialize () {
        return true;
      }

      public override float OnGetFrom () {
        return this.transform.localEulerAngles.y;
      }

      public override void OnUpdate (float easedTime) {
        this.quaternionValueFrom = Quaternion.Euler (this.transform.localEulerAngles.x, this.valueFrom, this.transform.localEulerAngles.z);
        this.quaternionValueTo = Quaternion.Euler (this.transform.localEulerAngles.x, this.valueTo, this.transform.localEulerAngles.z);
        this.transform.localRotation = Quaternion.Lerp (this.quaternionValueFrom, this.quaternionValueTo, easedTime);
      }
    }
  }
}