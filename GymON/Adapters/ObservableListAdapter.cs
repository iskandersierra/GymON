using System;
using Android.Widget;
using Android.App;
using System.Collections.ObjectModel;

namespace GymON
{
	public abstract class ObservableListAdapter<TItem> : BaseAdapter<TItem>
	{
		protected Activity context = null;
		protected ObservableCollection<TItem> list = null;

		public ObservableListAdapter (Activity context, ObservableCollection<TItem> items)
		{
			this.context = context;
			this.list = items;
		}

		public override TItem this[int index] {
			get {
				return list [index];
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return list.Count;
			}
		}
	}
}

