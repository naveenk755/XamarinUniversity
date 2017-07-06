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
    class SectionIndexBuillder
    {
        public static Java.Lang.Object[] BuildSections(List<Instructor> instructors)
        {
            List<string> result = new List<string>();
            
            foreach(var instructor in instructors)
            {
                var letter = instructor.Name[0].ToString();

                if (!result.Contains(letter))
                    result.Add(letter);
            }

            Java.Lang.Object[] jobject = new Java.Lang.Object[result.Count];

            for(int i=0;i<result.Count;i++)
            {
                jobject[i] = result[i];
            }

            return jobject;
        }

        public static Dictionary<int,int> BuildPositionForSection(List<Instructor> instructors)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            SortedSet<string> used = new SortedSet<string>();
            int section = -1;

            for(int i=0;i<instructors.Count;i++)
            {
                var letter = instructors[i].Name[0].ToString();
                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                    result.Add(section, i);
                }
            }

            return result;
        }

        public static Dictionary<int, int> BuildSectionForPosition(List<Instructor> instructors)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            SortedSet<string> used = new SortedSet<string>();
            int section = -1;

            for (int i = 0; i < instructors.Count; i++)
            {
                var letter = instructors[i].Name[0].ToString();
                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                }

                result.Add(i, section);
            }

            return result;
        }
    }
}