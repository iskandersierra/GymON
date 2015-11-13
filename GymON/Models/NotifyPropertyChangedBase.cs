using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GymON
{
	public class NotifyPropertyChangedBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged ([CallerMemberName] string propertyName = "")
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}

