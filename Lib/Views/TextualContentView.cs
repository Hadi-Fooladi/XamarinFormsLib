using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib
{
	public class TextualContentView : ContentView
	{
		private abstract class BP<T> : BPH<T, TextualContentView> { }

		public static readonly BindableProperty
			TextProperty = BP<string>.Create("Text", ""),
			FontSizeProperty = BP<double>.Create("FontSize", 16),
			FontFamilyProperty = BP<string>.Create("FontFamily", ""),
			TextColorProperty = BP<Color>.Create("TextColor", Color.Black),
			FontAttributesProperty = BP<FontAttributes>.Create("FontAttributes", FontAttributes.None),
			VerticalTextAlignmentProperty = BP<TextAlignment>.Create("VerticalTextAlignment", TextAlignment.Center),
			HorizontalTextAlignmentProperty = BP<TextAlignment>.Create("HorizontalTextAlignment", TextAlignment.Center);

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
			set => SetValue(TextColorProperty, value);
		}

		public double FontSize
		{
			get => (double)GetValue(FontSizeProperty);
			set => SetValue(FontSizeProperty, value);
		}

		public FontAttributes FontAttributes
		{
			get => (FontAttributes)GetValue(FontAttributesProperty);
			set => SetValue(FontAttributesProperty, value);
		}

		public string FontFamily
		{
			get => (string)GetValue(FontFamilyProperty);
			set => SetValue(FontFamilyProperty, value);
		}

		public TextAlignment VerticalTextAlignment
		{
			get => (TextAlignment)GetValue(VerticalTextAlignmentProperty);
			set => SetValue(VerticalTextAlignmentProperty, value);
		}

		public TextAlignment HorizontalTextAlignment
		{
			get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
			set => SetValue(HorizontalTextAlignmentProperty, value);
		}
	}
}
