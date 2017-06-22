using System.Windows;
using DartTraining.Factory;
using DartTraining.Switcher;
using DBInterface;

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
			var dataBaseService = new DataBaseService();
			var contextSwitcher = new ContextSwitcher(dataBaseService);
			contextSwitcher.CloseEvent += OnClose;
			this.DataContext = contextSwitcher.GetMainScreen();
		}

		private void OnClose(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
