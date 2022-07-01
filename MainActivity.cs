using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;

namespace MobileMailFinal
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn1;
        Button btn2;
        TextView txt1;
        TextView txt2;
        com.somee.mobilemail.MobileMailWS mobile = new com.somee.mobilemail.MobileMailWS(); 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Btn1_Click;

            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegistrarActivity));
            StartActivity(i);
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            txt1 = FindViewById<TextView>(Resource.Id.textView1);
            txt2 = FindViewById<TextView>(Resource.Id.textView2);
            bool token;

            token = mobile.Login(txt1.Text.ToString(), txt2.Text.ToString());


            if (token == false)
            {
                Intent i = new Intent(this, typeof(MenuActivity));
                i.PutExtra("user", txt1.Text.ToString());
                i.PutExtra("pass", txt2.Text.ToString());
                StartActivity(i);
            }
            else

            if (token == true)
            {
                AndroidX.AppCompat.App.AlertDialog.Builder alert = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
                alert.SetTitle("Invalido");
                alert.SetMessage("Este usuario no esta registrado.");

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}