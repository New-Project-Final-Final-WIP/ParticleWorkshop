using System;
using BaseX;
using FrooxEngine;
using FrooxEngine.UIX;
using CodeX;

namespace ParticleWorkshop
{
    [Category("Gareth")]
    class LiveParticleEditor : Component, ICustomInspector
    {
        public readonly SyncRef<ParticleStyle> ParticleStyle;
        public readonly SyncList<SyncLinearKey<color>> Colors;
        public readonly SyncList<SyncLinearKey<float>> Alpha;

        //Ui is needed
        public void BuildInspectorUI(UIBuilder ui)
        {
            WorkerInspector.BuildInspectorUI(this, ui);
        }
        protected override void OnAttach()
        {
            if (ParticleStyle != null&&!ParticleStyle.IsDisposed)
            {
                ParticleStyle.Changed += Update_Paticles;
                Colors.Changed += Colors_Changed;
                Alpha.Changed += Alpha_Changed;
            }
            base.OnAttach();
        }
        private void Colors_Changed(IChangeable obj)
        {
            ParticleStyle.Target.ColorOverLifetime.Clear();
            foreach (SyncLinearKey<color> key in Colors)
            {
                ParticleStyle.Target.ColorOverLifetime.Append(key);
            }
        }

        private void Alpha_Changed(IChangeable obj)
        {
            ParticleStyle.Target.AlphaOverLifetime.Clear();
            foreach (SyncLinearKey<float> key in Alpha)
            {
                ParticleStyle.Target.AlphaOverLifetime.Append(key);
            }
        }

        private void Update_Paticles(IChangeable obj)
        {
            ParticleStyle.Target.UseColorOverLifetime.Value = true;
            Colors_Changed(Colors);
            Alpha_Changed(Alpha);
        }

    }
}
