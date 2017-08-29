using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DartTraining.Switcher;

namespace DartTraining.Match
{
	public class MatchConfigController : IMatchConfigController
	{
		private readonly IContextSwitcher contextSwitcher;

		public MatchConfigController(IContextSwitcher contextSwitcher)
		{
			this.contextSwitcher = contextSwitcher;
		}

		public void Back()
		{
			this.contextSwitcher.GetMainMenu();
		}

		public void Start()
		{
		}

		public string GetRandomOpponent()
		{
			return string.Empty;
		}

		public List<string> GetAllOpponents()
		{
			return new List<string>();
		}
	}
}

