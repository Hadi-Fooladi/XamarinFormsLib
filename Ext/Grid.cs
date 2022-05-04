using Xamarin.Forms;

namespace HaFT.Xamarin.Forms.Ext
{
	public static class GridExt
	{
		public static void ArrangeUnifromly(this Grid grid, int nRows, int nCols)
		{
			var rows = new RowDefinitionCollection();
			for (int i = 0; i < nRows; i++)
				rows.Add(new RowDefinition());

			grid.RowDefinitions = rows;

			var cols = new ColumnDefinitionCollection();
			for (int i = 0; i < nCols; i++)
				cols.Add(new ColumnDefinition());

			grid.ColumnDefinitions = cols;
		}

		private static readonly RowDefinitionCollectionTypeConverter s_rdctc = new RowDefinitionCollectionTypeConverter();
		private static readonly ColumnDefinitionCollectionTypeConverter s_cdctc = new ColumnDefinitionCollectionTypeConverter();

		public static void SetRowsFormat(this Grid grid, string format)
		{
			grid.RowDefinitions = (RowDefinitionCollection)s_rdctc.ConvertFromInvariantString(format);
		}

		public static void SetColumnsFormat(this Grid grid, string format)
		{
			grid.ColumnDefinitions = (ColumnDefinitionCollection)s_cdctc.ConvertFromInvariantString(format);
		}
	}
}
