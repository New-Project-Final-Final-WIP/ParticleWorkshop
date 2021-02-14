using BaseX;
using FrooxEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleWorkshop
{
    public class SyncLinearKey<T> : SyncObject where T : IEquatable<T>
    {
        [Range(0.0f, 1f, "0.000")]
        public readonly Sync<float> TransitionTime;
        [Range(0.0f, 1f, "0.00")]
        public readonly Sync<T> Value;
        public static implicit operator LinearKey<T>(SyncLinearKey<T> key) => new LinearKey<T>(key.TransitionTime.Value, key.Value.Value);
    }
}
