using System;
using Xamarin.Forms;
using ImageButton = HaFT.Xamarin.Forms.Lib.Views.ImageButton;

namespace Test
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		int counter;

		void RoundedButton_OnTapped(object sender, EventArgs e)
		{
			var b = (ImageButton)sender;

			b.Image = counter++ % 2 == 0 ? (ImageSource)"pencil.png" : null;
		}

		void Edit_OnTapped(object sender, EventArgs e)
		{
			var b = (ImageButton)sender;

			b.Image = null;
		}
	}
}
