using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib.Views;

public abstract class ImageButtonBase : TextualContentView
{
	public event EventHandler Tapped;

	protected void fireTapped() { Tapped?.Invoke(this, EventArgs.Empty); }

	#region Bindable Properties
	abstract class BP<PropertyType> : BPH<PropertyType, ImageButtonBase> { }

	public static readonly BindableProperty
		BorderThicknessProperty = BP<double>.Create(nameof(BorderThickness), 2),
		BorderRadiusProperty = BP<double>.Create(nameof(BorderRadius), 20),
		BorderFillProperty = BP<Brush>.Create(nameof(BorderFill), Brush.Black),
		FillProperty = BP<Brush>.Create(nameof(Fill), Brush.Azure),
		InactiveFillProperty = BP<Brush>.Create(nameof(InactiveFill), Brush.LightGray),
		ImageProperty = BP<ImageSource>.Create(nameof(Image), null),
		ImageWidthProperty = BP<double>.Create(nameof(ImageWidth), 32),
		ImageHeightProperty = BP<double>.Create(nameof(ImageHeight), 32);

	public double BorderThickness
	{
		get => (double)GetValue(BorderThicknessProperty);
		set => SetValue(BorderThicknessProperty, value);
	}

	public Brush BorderFill
	{
		get => (Brush)GetValue(BorderFillProperty);
		set => SetValue(BorderFillProperty, value);
	}

	public double BorderRadius
	{
		get => (double)GetValue(BorderRadiusProperty);
		set => SetValue(BorderRadiusProperty, value);
	}

	public Brush Fill
	{
		get => (Brush)GetValue(FillProperty);
		set => SetValue(FillProperty, value);
	}

	public Brush InactiveFill
	{
		get => (Brush)GetValue(InactiveFillProperty);
		set => SetValue(InactiveFillProperty, value);
	}

	public ImageSource Image
	{
		get => (ImageSource)GetValue(ImageProperty);
		set => SetValue(ImageProperty, value);
	}

	public double ImageWidth
	{
		get => (double)GetValue(ImageWidthProperty);
		set => SetValue(ImageWidthProperty, value);
	}

	public double ImageHeight
	{
		get => (double)GetValue(ImageHeightProperty);
		set => SetValue(ImageHeightProperty, value);
	}
	#endregion
}
