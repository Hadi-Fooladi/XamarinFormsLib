using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public partial class CrossView
	{
		public CrossView()
		{
			InitializeComponent();
			Size = 20;
		}

		public event EventHandler Tapped;

		public double Size
		{
			set
			{
				_line1.X2 = _line1.Y2 =
				_line2.X2 = _line2.Y1 =
				WidthRequest = HeightRequest = value;
			}
		}

		public Color Color
		{
			set => _line1.Stroke = _line2.Stroke = new SolidColorBrush(value);
		}

		public double Thickness
		{
			set => _line1.StrokeThickness = _line2.StrokeThickness = value;
		}

		private void OnTapped(object sender, EventArgs e) { Tapped?.Invoke(this, EventArgs.Empty); }
	}
}
