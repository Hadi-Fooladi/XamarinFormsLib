using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaFT.Xamarin.Forms.Lib
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Border
	{
		public Border()
		{
			InitializeComponent();

			gInner.BindingContext =
			gOuter.BindingContext = this;

			gOuter.SetBinding(PaddingProperty, "BorderWidth");
			gOuter.SetBinding(BackgroundColorProperty, "BorderColor");
			gInner.SetBinding(BackgroundColorProperty, "BackgroundColor");
		}

		#region BindableProperties
		private abstract class BP<PropertyType> : BPH<PropertyType, Border> { }

		public static readonly BindableProperty
			BorderWidthProperty = BP<double>.Create("BorderWidth", 0),
			BorderColorProperty = BP<Color>.Create("BorderColor", Color.Transparent),
			BorderContentProperty = BP<View>.Create("BorderContent", null);

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

		public View BorderContent
		{
			get => (View)GetValue(BorderContentProperty);
			set => SetValue(BorderContentProperty, value);
		}
		#endregion

		protected override SizeRequest OnMeasure(double WidthConstraint, double HeightConstraint)
		{
			var V = BorderContent;
			if (V == null) return base.OnMeasure(WidthConstraint, HeightConstraint);

			double
				wPad = 2 * BorderWidth,
				hPad = 2 * BorderWidth;

			WidthConstraint -= wPad;
			HeightConstraint -= hPad;

			var SR = V.Measure(WidthConstraint, HeightConstraint);
			SR.Minimum += new Size(wPad, hPad);
			SR.Request += new Size(wPad, hPad);

			return SR;
		}
	}
}
