using System;

namespace GymON
{
	public class ExcerciseViewModel : NotifyPropertyChangedBase
	{
		public ExcerciseViewModel ()
		{
		}

		string excercise;
		public string Excercise {
			get {
				return excercise;
			}
			set {
				excercise = value;
				OnPropertyChanged ();
			}
		}

		bool done;
		public bool Done {
			get {
				return done;
			}
			set {
				done = value;
				OnPropertyChanged ();
			}
		}
	}
}

