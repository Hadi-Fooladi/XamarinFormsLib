using System;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;

using XamarinLabel = Xamarin.Forms.Label;
using Rectangle = Xamarin.Forms.Shapes.Rectangle;

namespace HaFT.Xamarin.Forms.Lib
{
	using Ext;

	public partial class RoundedButton
	{
		public RoundedButton()
		{
			InitializeComponent();

			R.BindingContext =
			L.BindingContext = this;

			R.SetBinding(Shape.FillProperty, "Fill");
			R.SetBinding(Shape.StrokeProperty, "Border");
			R.SetBinding(Rectangle.RadiusXProperty, "BorderRadius");
			R.SetBinding(Rectangle.RadiusYProperty, "BorderRadius");
			R.SetBinding(Shape.StrokeThicknessProperty, "BorderThickness");

			L.SetBinding(MarginProperty, "TextPadding");
			L.SetBinding(XamarinLabel.TextProperty, "Text");
			L.SetBinding(XamarinLabel.FontSizeProperty, "FontSize");
			L.SetBinding(XamarinLabel.TextColorProperty, "TextColor");

			this.AddClickHandler(FireTapped);

			SetBinding(_IsEnabledProperty, new Binding("IsEnabled") { Source = this });
		}

		#region BindableProperties
		private abstract class BP<PropertyType> : BPH<PropertyType, RoundedButton> { }

		public static readonly BindableProperty
			FillProperty = BP<Brush>.Create("Fill", Brush.Azure),
			InactiveFillProperty = BP<Brush>.Create("InactiveFill", Brush.LightGray),
			BorderProperty = BP<Brush>.Create("Border", Brush.Black),
			BorderRadiusProperty = BP<double>.Create("BorderRadius", 5),
			BorderThicknessProperty = BP<double>.Create("BorderThickness", 3),
			FontSizeProperty = BP<double>.Create("FontSize", 24),
			TextProperty = BP<string>.Create("Text", ""),
			TextColorProperty = BP<Color>.Create("TextColor", Color.Black),
			TextPaddingProperty = BP<Thickness>.Create("TextPadding", new Thickness(5));

		private static readonly BindableProperty
			_IsEnabledProperty = BP<bool>.Create("_IsEnabled", true, (b, value) => b.OnIsEnabledChanged(value));

		public Brush Fill
		{
			get => (Brush)GetValue(FillProperty);
			set => SetValue(FillProperty, value);
		}

		public Brush Border
		{
			get => (Brush)GetValue(BorderProperty);
			set => SetValue(BorderProperty, value);
		}

		public double BorderThickness
		{
			get => (double)GetValue(BorderThicknessProperty);
			set => SetValue(BorderThicknessProperty, value);
		}

		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
			set => SetValue(TextColorProperty, value);
		}

		public Thickness TextPadding
		{
			get => (Thickness)GetValue(TextPaddingProperty);
			set => SetValue(TextPaddingProperty, value);
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public double FontSize
		{
			get => (double)GetValue(FontSizeProperty);
			set => SetValue(FontSizeProperty, value);
		}

		public double BorderRadius
		{
			get => (double)GetValue(BorderRadiusProperty);
			set => SetValue(BorderRadiusProperty, value);
		}

		public Brush InactiveFill
		{
			get => (Brush)GetValue(InactiveFillProperty);
			set => SetValue(InactiveFillProperty, value);
		}
		#endregion

		public event EventHandler Tapped;
		private void FireTapped() => Tapped?.Invoke(this, EventArgs.Empty);

		private void OnIsEnabledChanged(bool value) => R.Fill = value ? Fill : InactiveFill;
	}
}