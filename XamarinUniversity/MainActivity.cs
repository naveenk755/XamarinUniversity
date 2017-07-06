using Android.App;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity
{
    [Activity(Label = "XamarinUniversity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            var list = FindViewById<ListView>(Resource.Id.InstructorsList);
            list.Adapter = new InstructorAdapter(this, InstructorData.Instructors);
            list.FastScrollEnabled = true;
        }
    }
}

