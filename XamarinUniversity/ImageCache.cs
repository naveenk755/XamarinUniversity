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
using Android.Graphics.Drawables;

namespace XamarinUniversity
{
    public class ImageCache
    {
        public static Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

        public static Drawable Get(string url, Context context)
        {

            if (!cache.ContainsKey(url))
            {
                Drawable drawable = Drawable.CreateFromStream(context.Assets.Open(url),null);
                cache.Add(url, drawable);
            }

            return cache[url];
        }
    }
}