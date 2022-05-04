using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Ext
{
	public static class ViewExt
	{
		public static void AddTappedHandler(this View view, Action handler)
		{
			view.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(handler) });
		}
	}
}
