using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib
{
	public class Border : ContentView
	{
		#region Bindable Properties
		private abstract class BP<PropertyType> : BPH<PropertyType, Border> { }

		public static readonly BindableProperty
			BorderWidthProperty = BP<double>.Create("BorderWidth", 0),
			BorderColorProperty = BP<Color>.Create("BorderColor", Color.Transparent);

		public double BorderWidth
		{
			get => (double)GetValue(BorderWidthProperty);
			set => SetValue(BorderWidthProperty, value);
		}

		public Color BorderColor
		{
			get => (Color)GetValue(BorderColorProperty);
			set => SetValue(BorderColorProperty, value);
		}
		#endregion
	}
}
