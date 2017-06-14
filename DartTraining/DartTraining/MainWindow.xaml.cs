using System.Windows;
using DartTraining.Factory;

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
			var factory = new ViewModelFactory();
			factory.CloseEvent += Factory_CloseEvent;
			this.DataContext = factory.CreateMainViewModel();
		}

		private void Factory_CloseEvent(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
