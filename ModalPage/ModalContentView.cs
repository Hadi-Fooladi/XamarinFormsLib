using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public class ModalContentView : ContentView, IModalView
	{
		#region IModalView
		public View View => this;

		public virtual void HandleBackButton() { Close(); }
		public virtual void Close() { Closed?.Invoke(this, EventArgs.Empty); }

		public event EventHandler Closed;
		#endregion
	}
}
