using System;
using System.Windows;
using Base;

namespace DartTrainingTests
{
	public class WindowGenerator
	{
		public static Window GenerateWindow(ViewModelBase viewModel)
		{
			return GenerateWindow(viewModel, 800, 600);
		}

		public static Window GenerateWindow(ViewModelBase viewModel, int width, int height)
		{
			var window = new Window
			{
				Content = viewModel,
				Width = width,
				Height = height,
				Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/DartTraining;component/Resources/ResourceDictionary.xaml") }
			};

			//window.Resources.MergedDictionaries.Add(new ResourceDictionary() {Source = new Uri("pack://application:,,,/DartTraining;Resources/ResourceDictionary.xaml") });
			return window;
		}

	}
}
