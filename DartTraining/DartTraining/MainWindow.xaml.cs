using System.Windows;
using DartTraining.Factory;
using DartTraining.Switcher;

namespace DartTraining
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			var contextSwitcher = new ContextSwitcher();
			contextSwitcher.CloseEvent += OnClose;
			this.DataContext = contextSwitcher.GetMainScreen();
		}

		private void OnClose(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
