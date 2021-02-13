using System;
using BaseX;
using FrooxEngine;
using FrooxEngine.UIX;
using CodeX;

namespace ParticleWorkshop
{
    public class SyncLinearKey<T> : SyncObject where T : IEquatable<T>
    {
        [Range(0.0f, 1f, "0.0000")]
        public readonly Sync<float> Position;
        public readonly Sync<T> Value;
        public static implicit operator LinearKey<T>(SyncLinearKey<T> key) => new LinearKey<T>(key.Position.Value, key.Value.Value);
    }
    [Category("Gareth")]
    class ParticleMaster : Component, ICustomInspector
    {
        private GradientStripTexture _gradientTexture;
        public readonly SyncList<SyncLinearKey<color>> Colors;
        public readonly SyncList<SyncLinearKey<float>> Alpha;

        public void BuildInspectorUI(UIBuilder ui)
        {
            if (_gradientTexture == null || _gradientTexture.IsDisposed)
            {
                _gradientTexture = ui.Root.AttachComponent<GradientStripTexture>();
                _gradientTexture.Format.Value = TextureFormat.RGB24;
                UpdateGradient();
            }
            WorkerInspector.BuildInspectorUI(this, ui);
            ui.RawImage(_gradientTexture);
            ui.Button("Generate Particle", (b, e) => { GenerateParticle(); });
        }
        protected override void OnAttach()
        {
            Colors.Changed += Colors_Changed;
            base.OnAttach();
        }
        private void Colors_Changed(IChangeable obj) => UpdateGradient();
        private void UpdateGradient()
        {
            _gradientTexture.Gradient.Clear();
            foreach (SyncLinearKey<color> key in Colors)
            {
                _gradientTexture.Gradient.Append(key);
            }
        }

        private void GenerateParticle()
        {
            var pSlot = Slot.AddSlot("Generated Particle");
            var pStyle = pSlot.AttachComponent<ParticleStyle>();
            var mat = pSlot.AttachComponent<UnlitMaterial>();
            foreach (SyncLinearKey<color> key in Colors)
            {
                pStyle.ColorOverLifetime.Append(key);
            }

            if (Alpha.Count != 0)
            {
                mat.BlendMode.Value = BlendMode.Alpha;
                foreach (SyncLinearKey<float> key in Alpha)
                {
                    pStyle.AlphaOverLifetime.Append(key);
                }
                
            }
            pStyle.Material.Target = mat;
            pStyle.UseColorOverLifetime.Value = true;   
            var pEmitter = pSlot.AttachComponent<PointEmitter>();
            var pSystem = pSlot.AttachComponent<ParticleSystem>();
            pEmitter.System.Target = pSystem;
            pSystem.Style.Target = pStyle;
        }
    }
}
