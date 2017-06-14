using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DartTraining.Switcher;

namespace DartTraining
{
	public class MainViewModel : ViewModelBase
	{
		private ViewModelBase context;
		private IContextSwitcher contextSwitcher;

		public MainViewModel(IContextSwitcher contextSwitcher)
		{
			this.contextSwitcher = contextSwitcher;
			this.Context = this.contextSwitcher.GetMainScreen();
		}

		public ViewModelBase Context
		{
			get { return this.context; }
			set
			{
				this.context = value; 
				OnPropertyChanged(nameof(this.Context));
			}
		}
	}
}
