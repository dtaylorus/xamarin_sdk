﻿using AdjustSdk;
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
using Windows.UI.Xaml.Navigation;
using AdjustDemo.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AdjustDemoWindowsUniversal_8_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnSimpleEvent_Click(object sender, RoutedEventArgs e)
        {
            var simpleEvent = new AdjustEvent("{yourSimpleEventToken}");
            Adjust.TrackEvent(simpleEvent);
        }

        private void btnRevenueEvent_Click(object sender, RoutedEventArgs e)
        {
            var revenueEvent = new AdjustEvent("{yourRevenueEventToken}");
            revenueEvent.SetRevenue(0.01, "EUR");
            Adjust.TrackEvent(revenueEvent);
        }

        private void btnCallbakEvent_Click(object sender, RoutedEventArgs e)
        {
            var callbackEvent = new AdjustEvent("{yourCallbackEventToken}");
            var localEnv = AdjustDemoSharedInfo.Environment;
            callbackEvent.AddPartnerParameter("key", localEnv);
            Adjust.TrackEvent(callbackEvent);
        }

        private void btnPartnerEvent_Click(object sender, RoutedEventArgs e)
        {
            var partnerEvent = new AdjustEvent("{yourPartnerEventToken}");
            var pclInfo = AdjustDemoPortableLibrary.AdjustDemoPCL.Info;
            partnerEvent.AddPartnerParameter("foo", pclInfo);
            Adjust.TrackEvent(partnerEvent);
        }

    }
}