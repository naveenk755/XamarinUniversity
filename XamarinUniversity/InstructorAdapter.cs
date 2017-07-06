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
using System.IO;
using Android.Graphics.Drawables;
using Java.Lang;

namespace XamarinUniversity
{
    public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
        Activity _activity;
        List<Instructor> Instructors;

        Java.Lang.Object[] sections = SectionIndexBuillder.BuildSections(InstructorData.Instructors);
        Dictionary<int, int> PositionForSection = SectionIndexBuillder.BuildPositionForSection(InstructorData.Instructors);
        Dictionary<int, int> SectionForPosition = SectionIndexBuillder.BuildSectionForPosition(InstructorData.Instructors);

        public InstructorAdapter(Activity activity, List<Instructor> instructors)
        {
            _activity = activity;
            Instructors = instructors;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return PositionForSection[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return SectionForPosition[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sections;
        }

        public override Instructor this[int position]
        {
            get
            {
                return Instructors[position];
            }
        }

        public override int Count
        {
            get
            {
                return Instructors.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if(view==null)
            {
                view = _activity.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);

                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var speciality = view.FindViewById<TextView>(Resource.Id.specialtyTextView);
                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);

                var vh = new ViewHolder() { Name = name, Speciality = speciality, Photo = photo };
                view.Tag = vh;
            }

            var holder = (ViewHolder)view.Tag;

            holder.Photo.SetImageDrawable(ImageCache.Get(Instructors[position].ImageUrl, _activity));
            holder.Name.Text = Instructors[position].Name;
            holder.Speciality.Text = Instructors[position].Specialty;
            return view;
        }
    }
}