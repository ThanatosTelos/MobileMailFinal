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
    [Activity(Label = "EnviarActivity")]
    public class EnviarActivity : Activity
    {
        Button btn1;
        EditText etxt1;
        EditText etxt2;
        EditText etxt3;
        EditText etxt4; 
        EditText etxt5; 
        string nombre;
        string contra;
        com.somee.mobilemail.MobileMailWS mobile = new com.somee.mobilemail.MobileMailWS();
          
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EnviarLayout);

            nombre = Intent.GetStringExtra("user");
            contra = Intent.GetStringExtra("pass");

            etxt1 = FindViewById<EditText>(Resource.Id.editText1);
            etxt1.Text = nombre;

            etxt2= FindViewById<EditText>(Resource.Id.editText2); 
            
            etxt3= FindViewById<EditText>(Resource.Id.editText3);

            etxt4 = FindViewById<EditText>(Resource.Id.editText4);
            etxt4.Text = DateTime.Today.ToString();

            etxt5 = FindViewById<EditText>(Resource.Id.editText5); 
            etxt5.Text = "No Leido";

            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            com.somee.mobilemail.MailSW mail = new com.somee.mobilemail.MailSW();

            nombre = Intent.GetStringExtra("user");
            contra = Intent.GetStringExtra("pass");

            Random myObject = new Random();
            int ranNum = myObject.Next(1, 1500);

            mail.Id = ranNum;
            mail.From = nombre;
            mail.To = etxt2.Text.ToString();
            mail.Content = etxt3.Text.ToString();
            mail.Date = etxt4.Text.ToString();
            mail.Status = etxt5.Text.ToString();

            int cre = mobile.AddMail(nombre, contra,mail);
            
            if (cre != 0)
            {
                AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
                alert.SetTitle("Enviado");
                alert.SetMessage("Enviado con excito.");

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else
                if (cre == 0)
                    {

                AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
                alert.SetTitle("Error");
                alert.SetMessage("Error al enviar.");

                Dialog dialog = alert.Create();
                dialog.Show();
            }

        }
    }
}
