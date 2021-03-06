﻿using GalaSoft.MvvmLight.Messaging;
using StudyBox.Core.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyBox.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LearningView : Page
    {
        public LearningView()
        {
            this.InitializeComponent();
            Messenger.Default.Register<StartStoryboardMessage>(this, x => StartStoryboard(x.StoryboardName));
        }

        private void StartStoryboard(string storyboardName)
        {
            var storyboard = FindName(storyboardName) as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }
    }
}
