using System;
using System.Text;

namespace ModalPageTest
{
	public partial class SampleNoteView
	{
		private readonly StringBuilder _sb = new StringBuilder();

		public SampleNoteView ()
		{
			InitializeComponent ();
		}

		private void Add_OnClicked(object sender, EventArgs e)
		{
			_sb.AppendLine(_entry.Text);
			_lbl.Text = _sb.ToString();
		}
	}
}
