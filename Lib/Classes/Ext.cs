using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib.Ext
{
	public static class __Ext__
	{
		public static void AddClickHandler(this View V, Action Handler)
			=> V.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(Handler) });
	}
}
