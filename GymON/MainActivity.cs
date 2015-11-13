using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.ObjectModel;
using System.Globalization;

namespace GymON
{
	[Activity (Label = "GymON", MainLauncher = true, Icon = "@drawable/ic_dumbellicon")]
	public class MainActivity : Activity
	{
		private TextView dayHeader;
		private ListView lvExcercises;
		private DateTime day;
		private ObservableCollection<ExcerciseViewModel> excercises;
		private ExcerciseListAdapter excercisesAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			dayHeader = FindViewById<TextView> (Resource.Id.dayHeader);
			lvExcercises = FindViewById<ListView> (Resource.Id.lvExcercises);

			day = DateTime.Today;
			// Esta lista se cargaría en el background desde la base de datos/servicio remoto/etc.
			excercises = new ObservableCollection<ExcerciseViewModel> ()
			{
				new ExcerciseViewModel { Excercise = "Biceps", Done = true },
				new ExcerciseViewModel { Excercise = "Triceps", Done = false },
			};
			excercisesAdapter = new ExcerciseListAdapter (this, excercises);
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			var dayName = DateTimeFormatInfo.CurrentInfo.DayNames [(int)day.DayOfWeek];
			dayHeader.SetText (dayName, TextView.BufferType.Normal);

			lvExcercises.Adapter = excercisesAdapter;
		}

		protected override void OnStop ()
		{
			base.OnStop ();
		}
	}
}


