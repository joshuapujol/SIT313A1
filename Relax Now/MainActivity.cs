using Android.App;
using Android.Widget;
using Android.Media;
using Android.OS;
using Android.Support.V7.App;

namespace Relax_Now
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MediaPlayer player1;
        MediaPlayer player2;
        MediaPlayer player3;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Changes image on click
            ImageView img = FindViewById<ImageView>(Resource.Id.imageView1);
            var imageSwitch1 = false;
            player1 = MediaPlayer.Create(this, Resource.Raw.Bird);
            img.Click += delegate 
            {
                if (imageSwitch1)
                {
                    img.SetImageResource(Resource.Drawable.BirdOff);


                    imageSwitch1 = false;
                }
                else
                {
                    img.SetImageResource(Resource.Drawable.BirdOn);

                    player1.Start();

                    imageSwitch1 = true;
                }
            };
            //Changes image on click
            ImageView img2 = FindViewById<ImageView>(Resource.Id.imageView2);
            var imageSwitch2 = false;
            player2 = MediaPlayer.Create(this, Resource.Raw.Campfire);
            img2.Click += delegate
            {
                if (imageSwitch2)
                {
                    img2.SetImageResource(Resource.Drawable.CampfireOff);

                    player2.Pause();

                    imageSwitch2 = false;
                }
                else
                {
                    img2.SetImageResource(Resource.Drawable.CampfireOn);

                    player2.Start();

                    imageSwitch2 = true;
                }
            };
            //Changes image on click
            ImageView img3 = FindViewById<ImageView>(Resource.Id.imageView3);
            var imageSwitch3 = false;
            player3 = MediaPlayer.Create(this, Resource.Raw.Frogs);
            img3.Click += delegate
            {
                if (imageSwitch3)
                {
                    img3.SetImageResource(Resource.Drawable.FrogsOff);

                    player3.Pause();

                    imageSwitch3 = false;
                }
                else
                {
                    img3.SetImageResource(Resource.Drawable.FrogsOn);

                    player3.Start();

                    imageSwitch3 = true;
                }
            };
            //Changes image on click
            ImageView img4 = FindViewById<ImageView>(Resource.Id.imageView4);
            var imageSwitch4 = false;
            img4.Click += delegate
            {
                if (imageSwitch4)
                {
                    img4.SetImageResource(Resource.Drawable.ChimesOff);
                    imageSwitch4 = false;
                }
                else
                {
                    img4.SetImageResource(Resource.Drawable.ChimesOn);
                    imageSwitch4 = true;
                }
            };
            //Changes image on click
            ImageView img5 = FindViewById<ImageView>(Resource.Id.imageView5);
            var imageSwitch5 = false;
            img5.Click += delegate
            {
                if (imageSwitch5)
                {
                    img5.SetImageResource(Resource.Drawable.CricketsOff);
                    imageSwitch5 = false;
                }
                else
                {
                    img5.SetImageResource(Resource.Drawable.CricketsOn);
                    imageSwitch5 = true;
                }
            };
            //Changes image on click
            ImageView img6 = FindViewById<ImageView>(Resource.Id.imageView6);
            var imageSwitch6 = false;
            img6.Click += delegate
            {
                if (imageSwitch6)
                {
                    img6.SetImageResource(Resource.Drawable.PanfluteOff);
                    imageSwitch6 = false;
                }
                else
                {
                    img6.SetImageResource(Resource.Drawable.PanfluteOn);
                    imageSwitch6 = true;
                }
            };
            //Changes image on click
            ImageView img7 = FindViewById<ImageView>(Resource.Id.imageView7);
            var imageSwitch7 = false;
            img7.Click += delegate
            {
                if (imageSwitch7)
                {
                    img7.SetImageResource(Resource.Drawable.WaterfallOff);
                    imageSwitch7 = false;
                }
                else
                {
                    img7.SetImageResource(Resource.Drawable.WaterfallOn);
                    imageSwitch7 = true;
                }
            };
            //Changes image on click
            ImageView img8 = FindViewById<ImageView>(Resource.Id.imageView8);
            var imageSwitch8 = false;
            img8.Click += delegate
            {
                if (imageSwitch8)
                {
                    img8.SetImageResource(Resource.Drawable.WhaleOff);
                    imageSwitch8 = false;
                }
                else
                {
                    img8.SetImageResource(Resource.Drawable.WhaleOn);
                    imageSwitch8 = true;
                }
            };
            //Changes image on click
            ImageView img9 = FindViewById<ImageView>(Resource.Id.imageView9);
            var imageSwitch9 = false;
            img9.Click += delegate
            {
                if (imageSwitch9)
                {
                    img9.SetImageResource(Resource.Drawable.WavesOff);
                    imageSwitch9 = false;
                }
                else
                {
                    img9.SetImageResource(Resource.Drawable.WavesOn);
                    imageSwitch9 = true;
                }
            };
        }
    }
}