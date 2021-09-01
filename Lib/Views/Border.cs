using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib
{
	public class Border : ContentView
	{
		#region Bindable Properties
		private abstract class BP<PropertyType> : BPH<PropertyType, Border> { }

		public static readonly BindableProperty
			BorderWidthProperty = BP<double>.Create(nameof(BorderWidth), 0),
			BorderRadiusProperty = BP<double>.Create(nameof(BorderRadius), 0),
			BorderColorProperty = BP<Color>.Create(nameof(BorderColor), Color.Transparent),
			FillColorProperty = BP<Color>.Create(nameof(FillColor), Color.Transparent);

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

		public Color FillColor
		{
			get => (Color)GetValue(FillColorProperty);
			set => SetValue(FillColorProperty, value);
		}

		public double BorderRadius
		{
			get => (double)GetValue(BorderRadiusProperty);
			set => SetValue(BorderRadiusProperty, value);
		}
		#endregion
	}
}
