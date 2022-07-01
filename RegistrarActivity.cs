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
    [Activity(Label = "RegistrarActivity")]
    public class RegistrarActivity : Activity
    {
        Button btn1;
        TextView txt1;
        TextView txt2;
        TextView txt3;
        TextView txt4;  
        com.somee.mobilemail.MobileMailWS mobile = new com.somee.mobilemail.MobileMailWS();
        com.somee.mobilemail.ResultRegister result = new com.somee.mobilemail.ResultRegister();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Registrar);

            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            txt1 = FindViewById<TextView>(Resource.Id.textView1);
            txt2 = FindViewById<TextView>(Resource.Id.textView2);
            txt3 = FindViewById<TextView>(Resource.Id.textView3);
            txt4 = FindViewById<TextView>(Resource.Id.textView4);

            byte temp = 1;

            result = mobile.Register(txt1.Text.ToString(), txt2.Text.ToString(), temp, txt3.Text.ToString(), txt4.Text.ToString());
            
            
            if (result.Band == true)
            {
                AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
                alert.SetTitle("Registrado");
                alert.SetMessage(result.Mensaje);

                Dialog dialog = alert.Create();
                dialog.Show();

                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }
            else
                if (result.Band == false)
            {
                AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
                alert.SetTitle("Error");
                alert.SetMessage("No se pudo registrar este usuario");

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }
    }


}