using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinUniversity
{
    public class ViewHolder: Java.Lang.Object
    {
        public TextView Name { get; set; }
        public TextView Speciality { get; set; }
        public ImageView Photo { get; set; }
    }
}