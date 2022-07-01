using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Arch.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileMailFinal
{
    internal class MailAdapter : BaseAdapter
    {

        Activity context;
        List<com.somee.mobilemail.MailSW> lista;

        public MailAdapter(Activity context, List<com.somee.mobilemail.MailSW> lista)
        {
            this.context = context;
            this.lista = lista;  
            
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.custom, null, false);
            }

            
            TextView txt1 = row.FindViewById<TextView>(Resource.Id.textView1);
            txt1.Text = lista[position].Id.ToString();
            
            TextView txt2 = row.FindViewById<TextView>(Resource.Id.textView2);
            txt2.Text = lista[position].From;
            
            TextView txt3 = row.FindViewById<TextView>(Resource.Id.textView3);
            txt3.Text = lista[position].To;
            
            TextView txt4 = row.FindViewById<TextView>(Resource.Id.textView4);
            txt4.Text = lista[position].Content;
            
            TextView txt5 = row.FindViewById<TextView>(Resource.Id.textView5);
            txt5.Text = lista[position].Date;
                
            TextView txt6 = row.FindViewById<TextView>(Resource.Id.textView6);
            txt6.Text = lista[position].Status;
           
                return row;
        }

        //Fill in cound here, currently 0
        public override int Count => lista.Count;


    }

    internal class MailAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}