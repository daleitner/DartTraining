using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using DartTraining.Switcher;

namespace DartTraining.Match
{
	public class MatchConfigViewModel : ViewModelBase
	{
		private readonly IContextSwitcher contextViewModel;

		public MatchConfigViewModel(IContextSwitcher contextViewModel)
		{
			this.contextViewModel = contextViewModel;
		}
	}
}
