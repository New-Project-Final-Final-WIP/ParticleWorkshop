using System;
using BaseX;
using FrooxEngine;
using FrooxEngine.UIX;

namespace ParticleWorkshop
{
    //TODO: Less weird repition, better use of objects!
    [Category("Gareth")]
    class RandomParticles : Component, ICustomInspector
    {
        [Range(1, 8)]
        public readonly Sync<int> RandomIterations;

        public void BuildInspectorUI(UIBuilder ui)
        {
            WorkerInspector.BuildInspectorUI(this, ui);
            ui.Button("Random Color Particle", (b, e) => { RandomColorGenerator(); });
            ui.Button("Random Alpha Particle", (b, e) => { RandomAlphaGenerator(); });
            ui.Button("Random Color and Alpha Particle", (b, e) => { RandomColorAlphaGenerator(); });
        }

        protected override void OnAttach()
        {
            RandomIterations.Value = 1;
            base.OnAttach();
        }

        private void RandomColorGenerator()
        {
            var pSlot = Slot.AddSlot("Random Colored Particle");
            var pStyle = pSlot.AttachComponent<ParticleStyle>();
            pStyle.Material.Target = pSlot.AttachComponent<UnlitMaterial>();
            for (int i = 0; i < RandomIterations; i++)
            {
                pStyle.ColorOverLifetime.InsertKey(RandomX.Range(0.0f, 1.0f), new color(RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f), 1.0f));
            }
            pStyle.UseColorOverLifetime.Value = true;
            var pEmitter = pSlot.AttachComponent<PointEmitter>();
            var pSystem = pSlot.AttachComponent<ParticleSystem>();
            pEmitter.System.Target = pSystem;
            pSystem.Style.Target = pStyle;
        }

        private void RandomAlphaGenerator()
        {
            var pSlot = Slot.AddSlot("Random Alpha Particle");
            var pStyle = pSlot.AttachComponent<ParticleStyle>();
            var mat = pSlot.AttachComponent<UnlitMaterial>();
            mat.BlendMode.Value = BlendMode.Alpha;
            pStyle.Material.Target = mat;
            for (int i = 0; i < RandomIterations; i++)
            {
                pStyle.AlphaOverLifetime.InsertKey(RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f));
            }
            pStyle.UseColorOverLifetime.Value = true;
            var pEmitter = pSlot.AttachComponent<PointEmitter>();
            var pSystem = pSlot.AttachComponent<ParticleSystem>();
            pEmitter.System.Target = pSystem;
            pSystem.Style.Target = pStyle;
        }

        private void RandomColorAlphaGenerator()
        {
            var pSlot = Slot.AddSlot("Random Colored/Alpha Particle");
            var pStyle = pSlot.AttachComponent<ParticleStyle>();
            var mat = pSlot.AttachComponent<UnlitMaterial>();
            mat.BlendMode.Value = BlendMode.Alpha;
            pStyle.Material.Target = mat;
            for (int i = 0; i < RandomIterations; i++)
            {
                pStyle.ColorOverLifetime.InsertKey(RandomX.Range(0.0f, 1.0f), new color(RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f), 1.0f));
                pStyle.AlphaOverLifetime.InsertKey(RandomX.Range(0.0f, 1.0f), RandomX.Range(0.0f, 1.0f));
            }
            pStyle.UseColorOverLifetime.Value = true;
            var pEmitter = pSlot.AttachComponent<PointEmitter>();
            var pSystem = pSlot.AttachComponent<ParticleSystem>();
            pEmitter.System.Target = pSystem;
            pSystem.Style.Target = pStyle;
        }
    }
}