using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Base;
using DartTraining.Switcher;

namespace DartTraining.Menu
{
	public class MenuViewModel : ViewModelBase
	{
		private RelayCommand startGameCommand;
		private RelayCommand startLigaCommand;
		private RelayCommand highlightCommand;
		private RelayCommand closeCommand;
		private readonly IContextSwitcher contextSwitcher;

		public MenuViewModel(IContextSwitcher contextSwitcher)
		{
			this.contextSwitcher = contextSwitcher;
		}

		public ICommand StartGameCommand
		{
			get
			{
				return this.startGameCommand ?? (this.startGameCommand = new RelayCommand(
					       param => StartGame()));
			}
		}

		public ICommand StartLigaCommand
		{
			get
			{
				return this.startLigaCommand ?? (this.startLigaCommand = new RelayCommand(
					       param => StartLiga()));
			}
		}

		public ICommand HighlightCommand
		{
			get
			{
				return this.highlightCommand ?? (this.highlightCommand = new RelayCommand(
					       param => OpenHighlights()));
			}
		}

		public ICommand CloseCommand
		{
			get
			{
				return this.closeCommand ?? (this.closeCommand = new RelayCommand(
					       param => CloseApplication()));
			}
		}

		private void StartGame()
		{
			throw new NotImplementedException();
		}

		private void StartLiga()
		{
			throw new NotImplementedException();
		}

		private void OpenHighlights()
		{
			throw new NotImplementedException();
		}

		private void CloseApplication()
		{
			this.contextSwitcher.CloseApplication();
		}

	}
}
