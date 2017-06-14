using DartTraining.Menu;

namespace DartTraining.Factory
{
	public interface IViewModelFactory
	{
		MainViewModel CreateMainViewModel();
		MenuViewModel CreateMenuViewModel();
		void CloseApplication();
	}
}
