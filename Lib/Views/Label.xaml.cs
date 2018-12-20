using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabel = Xamarin.Forms.Label;

namespace HaFT.Xamarin.Forms.Lib
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Label
	{
		#region Constructors
		public Label()
		{
			InitializeComponent();

			lbl.BindingContext =
			gInner.BindingContext =
			gOuter.BindingContext = this;

			gOuter.SetBinding(PaddingProperty, "BorderWidth");
			gOuter.SetBinding(BackgroundColorProperty, "BorderColor");

			gInner.SetBinding(PaddingProperty, "TextPadding");
			gInner.SetBinding(BackgroundColorProperty, "BackgroundColor");

			lbl.SetBinding(XamarinLabel.TextProperty, "Text");
			lbl.SetBinding(XamarinLabel.FontSizeProperty, "FontSize");
			lbl.SetBinding(XamarinLabel.TextColorProperty, "TextColor");
			lbl.SetBinding(XamarinLabel.FontFamilyProperty, "FontFamily");
			lbl.SetBinding(XamarinLabel.FontAttributesProperty, "FontAttributes");
			lbl.SetBinding(XamarinLabel.VerticalTextAlignmentProperty, "VerticalTextAlignment");
			lbl.SetBinding(XamarinLabel.HorizontalTextAlignmentProperty, "HorizontalTextAlignment");
		}
		#endregion

		#region BindableProperties
		private abstract class BP<PropertyType> : BPH<PropertyType, Label> { }

		public static readonly BindableProperty
			BorderWidthProperty = BP<double>.Create("BorderWidth", 0),
			BorderColorProperty = BP<Color>.Create("BorderColor", Color.Transparent),
			TextPaddingProperty = BP<Thickness>.Create("TextPadding", new Thickness(0));

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

		public Thickness TextPadding
		{
			get => (Thickness)GetValue(TextPaddingProperty);
			set => SetValue(TextPaddingProperty, value);
		}
		#endregion

		protected override SizeRequest OnMeasure(double WidthConstraint, double HeightConstraint)
		{
			double
				wPad = TextPadding.HorizontalThickness + 2 * BorderWidth,
				hPad = TextPadding.VerticalThickness + 2 * BorderWidth;

			WidthConstraint -= wPad;
			HeightConstraint -= hPad;

			var SR = lbl.Measure(WidthConstraint, HeightConstraint);
			SR.Minimum += new Size(wPad, hPad);
			SR.Request += new Size(wPad, hPad);

			return SR;
		}
	}
}
