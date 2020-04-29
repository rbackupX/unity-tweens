using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens.Core.Drivers {
  [AddComponentMenu ("")]
  public class AudioSourceVolumeTween : Tween<float> {
    private AudioSource audioSource;

    public override bool OnInitialize () {
      this.audioSource = this.gameObject.GetComponent<AudioSource> ();
      return this.audioSource != null;
    }

    public override float OnGetFrom () {
      return this.audioSource.volume;
    }

    public override void OnUpdate (float easedTime) {
      this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
      this.audioSource.volume = this.valueCurrent;
    }
  }
}