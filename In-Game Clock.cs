using System;
using UnityEngine;
using In_Game_Clock.Extensions;
using KSP.IO;

namespace In_Game_Clock
{
    public class DigitalClock : PartModule
    {
        private static Rect _windowPosition = new Rect();
        private GUIStyle _windowStyle, _labelStyle;
        private bool _hasInitStyles = false;

        public override void OnStart(StartState state)
        {
            if (state != StartState.Editor)
            {
                if (!_hasInitStyles) InitStyles();
                RenderingManager.AddToPostDrawQueue(0, OnDraw);
            }
        }

        public override void OnSave(ConfigNode node)
        {
            PluginConfiguration config = PluginConfiguration.CreateForType<DigitalClock>();

            config.SetValue("Window Position", _windowPosition);
            config.save();
        }

        public override void OnLoad(ConfigNode node)
        {
            PluginConfiguration config = PluginConfiguration.CreateForType<DigitalClock>();

            config.load();
            _windowPosition = config.GetValue<Rect>("Window Position");
        }

        private void OnDraw()
        {
            if (this.vessel == FlightGlobals.ActiveVessel && this.part.IsPrimary(this.vessel.parts, this.ClassID))
            {
                _windowPosition = GUILayout.Window(10000, _windowPosition, OnWindow, "Real World Time:", _windowStyle);

                if (_windowPosition.x == 0f && _windowPosition.y == 0f)
                    _windowPosition = _windowPosition.HighLeftScreen();
            }
        }

        private void OnWindow(int windowID)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(DateTime.Now.ToLongTimeString(), _labelStyle);
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

        private void InitStyles()
        {
            _windowStyle = new GUIStyle(HighLogic.Skin.window);
            _windowStyle.fixedWidth = 150f;

            _labelStyle = new GUIStyle(HighLogic.Skin.label);
            _labelStyle.stretchWidth = true;

            _hasInitStyles = true;
        }
    }
}
