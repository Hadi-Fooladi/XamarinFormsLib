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

		#region Fields
		private readonly IModalView _view;
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
		#endregion

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

		#region Public Methods
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

		public void SetAbsoluteWidth(double value) { SetHorzLayout(new GridLength(value), GridLength.Star); }
		public void SetAbsoluteHeight(double value) { SetVertLayout(new GridLength(value), GridLength.Star); }

		public void SetRelativeWidth(double percentage) { SetRelativeSize(percentage, SetHorzLayout); }
		public void SetRelativeHeight(double percentage) { SetRelativeSize(percentage, SetVertLayout); }

		public void SetAutoWidth() { SetHorzLayout(GridLength.Auto, GridLength.Star); }
		public void SetAutoHeight() { SetVertLayout(GridLength.Auto, GridLength.Star); }
		#endregion

		private void Close() { _semaphore.Release(); }

		private void SetHorzLayout(GridLength main, GridLength margin)
		{
			_grid.ColumnDefinitions = new ColumnDefinitionCollection
			{
				convert(margin),
				convert(main),
				convert(margin)
			};

			ColumnDefinition convert(GridLength length) => new ColumnDefinition { Width = length };
		}

		private void SetVertLayout(GridLength main, GridLength margin)
		{
			_grid.RowDefinitions = new RowDefinitionCollection
			{
				convert(margin),
				convert(main),
				convert(margin)
			};

			RowDefinition convert(GridLength length) => new RowDefinition { Height = length };
		}

		public void SetRelativeSize(double percentage, Action<GridLength, GridLength> layoutAction)
		{
			if (percentage < 0 || percentage > 100)
				throw new ArgumentException("invalid percentage", nameof(percentage));

			var reminder = 100 - percentage;
			var blank = reminder / 2;

			layoutAction(new GridLength(percentage, GridUnitType.Star), new GridLength(blank, GridUnitType.Star));
		}

		#region Event Handlers
		private void Cross_OnTapped(object sender, EventArgs e) { _view.Close(); }
		#endregion
	}
}
