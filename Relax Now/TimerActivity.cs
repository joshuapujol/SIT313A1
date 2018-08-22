using System;
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

        RadialProgressView radialProgressView;
        Button btnStart, btnStop;
        TextView txtTimer;

        Timer timer;

        int hours = 0, min = 0, sec = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TimerActivity);
            // Create your application here

            var timerBtn = FindViewById<Button>(Resource.Id.button3);

            timerBtn.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(MainActivity));
                StartActivity(nextActivity);
            };

            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnStop = FindViewById<Button>(Resource.Id.btnStop);
            txtTimer = FindViewById<TextView>(Resource.Id.txtTimer);

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