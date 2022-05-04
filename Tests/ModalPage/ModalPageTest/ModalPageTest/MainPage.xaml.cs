using System;
using System.Threading.Tasks;

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
		private void Open_OnClicked(object sender, EventArgs e)
		{
			var lbl = new Label
			{
				Text = "This is a test.",
				FontSize = 32
			};

			ModalPage.FromView(lbl, "Modal Page").ShowAsync();
		}

		private async void Notepad_OnClicked(object Sender, EventArgs E)
		{
			const string
				ABS = "Abs",
				REL = "Rel",
				AUTO = "Auto";

			var page = new ModalPage(new SampleNoteView());

			{
				const string DIR = "Width";
				var mode = await select(DIR);
				if (mode == AUTO)
					page.SetAutoWidth();
				else
				{
					int num = await getInt(DIR);
					if (mode == ABS) page.SetAbsoluteWidth(num);
					else page.SetRelativeWidth(num);
				}
			}

			{
				const string DIR = "Height";
				var mode = await select(DIR);
				if (mode == AUTO)
					page.SetAutoHeight();
				else
				{
					int num = await getInt(DIR);
					if (mode == ABS) page.SetAbsoluteHeight(num);
					else page.SetRelativeHeight(num);
				}
			}

			await page.ShowAsync();

			async Task<string> select(string title) => await DisplayActionSheet(title, null, null, ABS, REL, AUTO);

			async Task<int> getInt(string title)
			{
				for (;;)
				{
					var s = await DisplayPromptAsync(title, "");
					if (int.TryParse(s, out var num))
						return num;
				}
			}
		}
		#endregion
	}
}
