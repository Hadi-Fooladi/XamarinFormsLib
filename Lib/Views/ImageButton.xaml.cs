using System;

namespace HaFT.Xamarin.Forms.Lib.Views;

partial class ImageButton
{
	public ImageButton()
	{
		InitializeComponent();
	}

	void OnTapped(object sender, EventArgs e) { fireTapped(); }
}
