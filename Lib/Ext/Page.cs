using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib.Ext
{
	public static partial class __Ext__
	{
		public static Task ShowMessage(this Page page, string title, string message)
			=> page.DisplayAlert(title, message, "OK");

		public static Task ShowMessage(this Page page, string message) => page.ShowMessage("", message);
		public static Task ShowError(this Page page, string message) => page.ShowMessage("Error", message);
		public static Task ShowError(this Page page, Exception ex) => page.ShowError(ex.Message);

		public static async Task<bool?> ShowYesNoPrompt(this Page page, string message)
		{
			const string yes = "Yes", no = "No";

			var response = await page.DisplayActionSheet(message, null, null, yes, no);

			switch (response)
			{
			case no: return false;
			case yes: return true;
			default: return null;
			}
		}
	}
}
