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
			var page = new ModalPage(new SampleNoteView()) { Padding = 0 };

			await set("Width", page.SetAutoWidth, page.SetAbsoluteWidth, page.SetRelativeWidth);
			await set("Height", page.SetAutoHeight, page.SetAbsoluteHeight, page.SetRelativeHeight);

			await page.ShowAsync();

			#region Nested Functions
			const string
				ABS = "Abs",
				REL = "Rel",
				AUTO = "Auto",
				NONE = "None";
			
			async Task<string> select(string title) => await DisplayActionSheet(title, null, null, ABS, REL, AUTO, NONE);

			async Task<int> getInt(string title)
			{
				for (;;)
				{
					var s = await DisplayPromptAsync(title, "");
					if (int.TryParse(s, out var num))
						return num;
				}
			}
			
			async Task set(string title, Action auto, Action<double> abs, Action<double> rel)
			{
				var mode = await select(title);

				switch (mode)
				{
				case NONE: break;
				case AUTO: auto(); break;
				default: (mode == ABS ? abs : rel)(await getInt(title)); break;
				}
			}
			#endregion
		}
		#endregion
	}
}
