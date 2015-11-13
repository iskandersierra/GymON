using System;
using Android.Widget;
using Android.App;
using System.Collections.ObjectModel;
using Android.Views;

namespace GymON
{
	public class ExcerciseListAdapter : ObservableListAdapter<ExcerciseViewModel>
	{
		public ExcerciseListAdapter (Activity context, ObservableCollection<ExcerciseViewModel> items) 
			: base(context, items) {
		}

		#region implemented abstract members of BaseAdapter

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = list [position];

			CheckedTextView view = convertView as CheckedTextView ??
				context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemChecked, parent, false) as CheckedTextView;

			RefreshView (item, view);

			return view;
		}

		void RefreshView (ExcerciseViewModel item, CheckedTextView view)
		{
			view.SetText (item.Excercise, TextView.BufferType.Normal);
			view.Checked = item.Done;
		}

		public override int GetItemViewType (int position)
		{
			return Android.Resource.Layout.SimpleListItemChecked;
		}

		public override int ViewTypeCount {
			get {
				return 1;
			}
		}

		#endregion
	}
}

