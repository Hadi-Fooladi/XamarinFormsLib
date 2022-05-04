using System;
using Xamarin.Forms;
using HaFT.Xamarin.Forms;

namespace ModalPageTest
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		#region Event Handlers
		private void Open_OnClicked(object Sender, EventArgs E)
		{
			var lbl = new Label
			{
				Text = "This is a test.",
				FontSize = 32
			};

			ModalPage.FromView(lbl, "Modal Page").ShowAsync();
		}
		#endregion
	}
}
