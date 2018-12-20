using System;
using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Lib
{
	/// <summary>
	/// Bindable Property Helper
	/// </summary>
	public abstract class BPH<PropertyType, ClassType> where ClassType : BindableObject
	{
		public delegate void dlgPropertyChanged(ClassType Sender, PropertyType OldValue, PropertyType NewValue);

		public static BindableProperty Create(string Name, PropertyType Default) => BindableProperty.Create(Name, typeof(PropertyType), typeof(ClassType), Default);

		public static BindableProperty Create(string Name, PropertyType Default, dlgPropertyChanged OnChanged)
			=> BindableProperty.Create
			(
				Name, typeof(PropertyType), typeof(ClassType), Default, BindingMode.OneWay, null,
				(Sender, OldValue, NewValue) => OnChanged((ClassType)Sender, (PropertyType)OldValue, (PropertyType)NewValue)
			);

		public static BindableProperty Create(string Name, PropertyType Default, Action<ClassType, PropertyType> OnChanged)
			=> BindableProperty.Create
			(
				Name, typeof(PropertyType), typeof(ClassType), Default, BindingMode.OneWay, null,
				(Sender, OldValue, NewValue) => OnChanged((ClassType)Sender, (PropertyType)NewValue)
			);
	}
}
