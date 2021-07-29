using System;
using Xamarin.Forms;
using HaFT.Xamarin.Forms.Lib;
using HaFT.Xamarin.Forms.Lib.Ext;

using Button = HaFT.Xamarin.Forms.Lib.Button;

namespace Test
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			var L = new HaFT.Xamarin.Forms.Lib.Label
			{
				Text = "OK",
				BorderColor = Color.Coral,
				BackgroundColor = Color.CornflowerBlue,
				BorderWidth = 3
			};
			G.Children.Add(L, 0, 0);

			lbl.Text = "Oh, Reallllllllllllllllllllllly Sanp!!!!!!!!!!!!!!!";
		}

		private void Button_OnClicked(Button B)
		{
			DisplayAlert("", B.Text, "OK");
			B.Text += "@";
		}

		private async void RoundedButton_OnTapped(object sender, EventArgs e)
		{
			var b = await this.ShowYesNoPrompt("Please answer");

			await this.ShowMessage(b.ToString());
		}
	}
}
