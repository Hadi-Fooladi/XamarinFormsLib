using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public class ModalContentView : ContentView, IModalView
	{
		public bool IgnoreBackButton { get; set; } = false;

		#region IModalView
		public View View => this;

		/// <summary>
		/// Default implementation: Calls <see cref="Close" /> to close the page (only if <see cref="IgnoreBackButton" /> is false)
		/// </summary>
		public virtual void HandleBackButton()
		{
			if (!IgnoreBackButton)
				Close();
		}

		/// <summary>
		/// Default implementation: Triggers the <see cref="Closed"/> event to close the page
		/// </summary>
		public virtual void Close() { Closed?.Invoke(this, EventArgs.Empty); }

		public event EventHandler Closed;
		#endregion
	}
}
