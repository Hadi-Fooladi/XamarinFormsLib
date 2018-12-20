using System;
using Xamarin.Forms.Xaml;

namespace HaFT.Xamarin.Forms.Lib
{
	using Ext;

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public class Button : Label
	{
		public delegate void dlg(Button Sender);

		#region Constructors
		public Button()
		{
			this.AddClickHandler(() =>
			{
				if (IsEnabled)
					Clicked?.Invoke(this);
			});
		}

		public static Button Create(string Text, Action OnClicked)
		{
			var B = new Button { Text = Text };
			B.Clicked += _ => OnClicked();
			return B;
		}
		#endregion

		public event dlg Clicked;
	}
}
