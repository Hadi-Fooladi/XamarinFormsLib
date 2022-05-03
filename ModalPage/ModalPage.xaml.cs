using System;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HaFT.Xamarin.Forms
{
	public partial class ModalPage
	{
		public static bool ShowAnimation = true;

		#region Constructors
		public ModalPage(IModalView view, string header = null)
		{
			InitializeComponent();

			_view = view;
			_cv.Content = view.View;

			view.Closed += (_, __) => Close();

			if (header != null)
			{
				Header = header;
				IsHeaderVisible = true;
			}
		}

		public static ModalPage FromView(View view, string header = null)
			=> new ModalPage(new ModalContentView { Content = view }, header);
		#endregion

		protected override bool OnBackButtonPressed()
		{
			_view.HandleBackButton();
			return true;
		}

		private readonly IModalView _view;
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

		#region Properties
		public Color BorderColor
		{
			set => _rect.Stroke = new SolidColorBrush(value);
		}

		public double BorderWidth
		{
			get => _rect.StrokeThickness;
			set
			{
				_rect.StrokeThickness = value;
				_cv.Margin = new Thickness(value + 8);
			}
		}

		public Brush Fill
		{
			get => _rect.Fill;
			set => _rect.Fill = value;
		}

		public bool IsHeaderVisible
		{
			get => _headerLayout.IsVisible;
			set => _headerLayout.IsVisible = value;
		}

		public string Header
		{
			get => _headerLabel.Text;
			set => _headerLabel.Text = value;
		}

		public ImageSource HeaderImageSource
		{
			get => _headerImage.Source;
			set
			{
				_headerImage.Source = value;
				_headerImage.IsVisible = value != null;
			}
		}
		#endregion

		/// <summary>
		/// Should be called once
		/// </summary>
		public Task ShowAsync() => ShowAsync(ShowAnimation);

		/// <summary>
		/// Should be called once
		/// </summary>
		public Task ShowAsync(bool showAnimation) => ShowAsync(Application.Current.MainPage.Navigation, showAnimation);

		/// <summary>
		/// Should be called once
		/// </summary>
		public Task ShowAsync(INavigation nav) => ShowAsync(nav, ShowAnimation);

		/// <summary>
		/// Should be called once
		/// </summary>
		public async Task ShowAsync(INavigation nav, bool showAnimation)
		{
			await nav.PushModalAsync(this, showAnimation);

			await _semaphore.WaitAsync();

			await nav.PopModalAsync(showAnimation);
		}

		private void Close() { _semaphore.Release(); }

		#region Event Handlers
		private void Cross_OnTapped(object sender, EventArgs e) { _view.Close(); }
		#endregion
	}
}
