﻿using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using HA4IoT.Contracts.Adapters;

namespace HA4IoT.Simulator.Controls
{
    public class UIMotionDetectorAdapter : IMotionDetectorAdapter
    {
        private readonly CheckBox _checkBox;

        public UIMotionDetectorAdapter(CheckBox checkBox)
        {
            _checkBox = checkBox ?? throw new ArgumentNullException(nameof(checkBox));
        }

        public event EventHandler MotionDetectionBegin;
        public event EventHandler MotionDetectionEnd;

        public void Refresh()
        {
        }

        public void Connect()
        {
            _checkBox.Checked += (s, e) => OnMotionDetectionBegin();
            _checkBox.Unchecked += (s, e) => OnMotionDetectionEnd();
        }

        private void OnMotionDetectionBegin()
        {
            Task.Run(() => MotionDetectionBegin?.Invoke(this, EventArgs.Empty));
        }

        private void OnMotionDetectionEnd()
        {
            Task.Run(() => MotionDetectionEnd?.Invoke(this, EventArgs.Empty));
        }
    }
}
