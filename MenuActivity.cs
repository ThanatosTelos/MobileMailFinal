using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileMailFinal
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        Button btn1;
        Button btn2;
        Button btn3;
        string nombre;
        string contra;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MenuLayout);

            nombre = Intent.GetStringExtra("user");
            contra = Intent.GetStringExtra("pass");

            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Btn1_Click;

            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Click += Btn2_Click;

            btn3 = FindViewById<Button>(Resource.Id.button3);   
            btn3.Click += Btn3_Click;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(EntradaActivity));
            i.PutExtra("user", nombre);
            i.PutExtra("pass", contra);
            StartActivity(i);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegistrarActivity));
            i.PutExtra("user", nombre);
            i.PutExtra("pass", contra);
            StartActivity(i);
        }
    }
}