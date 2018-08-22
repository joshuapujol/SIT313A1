using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Relax_Now
{
    [Activity(Label = "recordActivity")]
    public class recordActivity : Activity
    {

        //Initialise Variables

        Button btnRecord, btnStopRecord, btnPlay, btnStop;
        string pathsave = "";
        MediaRecorder mediaRecorder;
        MediaPlayer mediaPlayer;


        private const int REQUEST_PERMISSION_CODE = 1000;

        private bool isGrantedPermission = false;

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch(requestCode)
            {
                case REQUEST_PERMISSION_CODE:
                    {
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            Toast.MakeText(this, "granted", ToastLength.Short).Show();
                            isGrantedPermission = true;
                        }
                        else
                        {
                            Toast.MakeText(this, "granted", ToastLength.Short).Show();
                            isGrantedPermission = false;
                        }
                    }
                    break;
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.recordActivity);
            // Create your application here

            // Request permissions 
            if(CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted 
                && CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[]
                    {
                        Manifest.Permission.WriteExternalStorage,
                        Manifest.Permission.RecordAudio
                    }, REQUEST_PERMISSION_CODE);
            }
            else
            {
                isGrantedPermission = true;
            }
            btnPlay = FindViewById<Button>(Resource.Id.btnRPlay);
            btnStop = FindViewById<Button>(Resource.Id.btnRStop);
            btnRecord = FindViewById<Button>(Resource.Id.btnRecord);
            btnStopRecord = FindViewById<Button>(Resource.Id.btnStopRecord);

            btnStop.Enabled = false;
            btnPlay.Enabled = false;
            btnStopRecord.Enabled = false;

            btnRecord.Click += delegate
            {
                RecordAudio();
            };

            btnStopRecord.Click += delegate
            {
                StopRecorder();
            };

            btnPlay.Click += delegate
            {
                StartLastRecord();
            };

            btnStop.Click += delegate
            {
                StopLastRecord();
            };
        }

        private void StopLastRecord()
        {
            btnStop.Enabled = false;
            btnStopRecord.Enabled = false;
            btnPlay.Enabled = true;
            btnRecord.Enabled = true;

            if(mediaPlayer != null)
            {
                mediaPlayer.Stop();
                mediaPlayer.Release();
                SetupMediaRecorder();
            }
        }

        private void StartLastRecord()
        {
            btnStopRecord.Enabled = false;
            btnStop.Enabled = true;
            btnRecord.Enabled = false;

            mediaPlayer = new MediaPlayer();
            try
            {
                mediaPlayer.SetDataSource(pathsave);
                mediaPlayer.Prepare();
            }catch(Exception ex)
            {
                Log.Debug("DEBUG", ex.Message);
            }

            mediaPlayer.Start();

            Toast.MakeText(this, "Playing Recording", ToastLength.Short).Show();
        }

        private void StopRecorder()
        {
            mediaRecorder.Stop();
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
            btnStopRecord.Enabled = false;
            btnRecord.Enabled = true;

            Toast.MakeText(this, "Stop Recording", ToastLength.Short).Show();
        }

        private void RecordAudio()
        {
            if(isGrantedPermission)
            {
                pathsave = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString() + "/" + new Guid().ToString() + "_audio.3gp";

                SetupMediaRecorder();
                try
                {
                    mediaRecorder.Prepare();
                    mediaRecorder.Start();

                    btnPlay.Enabled = false;
                    btnStopRecord.Enabled = true;
                }
                catch(Exception ex)
                {
                    Log.Debug("DEBUG",ex.Message);
                }

                Toast.MakeText(this, "Recording", ToastLength.Short).Show();
            }
        }

        private void SetupMediaRecorder()
        {
            mediaRecorder = new MediaRecorder();
            mediaRecorder.SetAudioSource(AudioSource.Mic);
            mediaRecorder.SetOutputFormat(OutputFormat.ThreeGpp);
            mediaRecorder.SetAudioEncoder(AudioEncoder.AmrNb);
            mediaRecorder.SetOutputFile(pathsave);
        }
    }
}