using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public interface IModalView
	{
		/// <summary>
		/// Should always return the same value
		/// </summary>
		View View { get; }

		void Close();
		void HandleBackButton();

		event EventHandler Closed;
	}
}
