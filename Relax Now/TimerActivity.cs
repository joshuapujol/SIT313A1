﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using RadialProgress;
using Android.Widget;
using System.Timers;

namespace Relax_Now
{
    [Activity(Label = "TimerActivity")]
    public class TimerActivity : Activity
    {
        // Decalare Variables
        RadialProgressView radialProgressView;
        Button btnStart, btnStop;
        TextView txtTimer;

        Timer timer;

        int hours = 0, min = 0, sec = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set Activity 
            SetContentView(Resource.Layout.TimerActivity);

            // Buttons for other activities 
            var soundsBtn = FindViewById<Button>(Resource.Id.button3);
            var recordBtn = FindViewById<Button>(Resource.Id.button2);

            // Go back to record Activity
            recordBtn.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(recordActivity));
                StartActivity(nextActivity);
            };

            // Go back to sounds Activity
            soundsBtn.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(MainActivity));
                StartActivity(nextActivity);
            };

            // Buttons for timer
            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnStop = FindViewById<Button>(Resource.Id.btnStop);
            txtTimer = FindViewById<TextView>(Resource.Id.txtTimer);

            // Begin timer
            btnStart.Click += delegate {
                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            };

            btnStop.Click += delegate
            {
                timer.Dispose();
                timer = null;
            };

        }

        // Function to add time. 
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                min++;
                sec = 0;
            }
            if (min == 60)
            {
                hours++;
                min = 0;
            }
            RunOnUiThread(() => { txtTimer.Text = $"{hours}:{min}:{sec}"; });

        }
    }
}