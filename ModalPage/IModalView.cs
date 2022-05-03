using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public interface IModalView
	{
		View View { get; }

		void Close();
		void HandleBackButton();

		event EventHandler Closed;
	}
}
