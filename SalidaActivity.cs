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
    [Activity(Label = "SalidaActivity")]
    public class SalidaActivity : Activity
    {
        string nombre;
        string contra;
        ListView lista;
        com.somee.mobilemail.MobileMailWS mobile = new com.somee.mobilemail.MobileMailWS();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BandejaSalida);

            nombre = Intent.GetStringExtra("user");
            contra = Intent.GetStringExtra("pass");

            lista = FindViewById<ListView>(Resource.Id.listView1);

            List<com.somee.mobilemail.MailSW> list = new List<com.somee.mobilemail.MailSW>();

            foreach (var item in mobile.InBox(nombre, contra))
            {
                list.Add(item);
            }

            lista.Adapter = new MailAdapter(this, list);
        }
    }
}