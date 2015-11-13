using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GymON
{
	[Activity (Label = "GymON", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			ListView lv = FindViewById<ListView> (Resource.Id.listView);
		    var dict = new Dictionary<string, bool>()
		    {
		        {"hercules", true},
		        {"prompt", false},
		        {"bycicle", false},
		        {"balls", true}
		    };
            lv.Adapter = new ImgTextArrayAdapter(this, dict.Keys.ToArray(), dict);
        }
    }

    public class ImgTextArrayAdapter : ArrayAdapter<string> {
        private Context context;
        private string[] values;
        private Dictionary<string, bool> _mapper;

        public ImgTextArrayAdapter(Context context, string[] values, Dictionary<string, bool> mapper)
            : base(context, Resource.Layout.ExerciseItemLayout, values)
        {
            this.context = context;
            this.values = values;
            _mapper = mapper;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
            var rowView = inflater.Inflate(Resource.Layout.ExerciseItemLayout, parent, false);
            var textView = (TextView) rowView.FindViewById(Resource.Id.caption);
            var imageView = (ImageView) rowView.FindViewById(Resource.Id.image);
            textView.Text = values[position];
            // Change the icon for Windows and iPhone
            var s = values[position];
            var val = _mapper[s];
            var id = val ? Resource.Drawable.check : Resource.Drawable.close;
            imageView.SetImageResource(id);
            
            return rowView;
        }
    }
}


