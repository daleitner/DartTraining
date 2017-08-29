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
			throw new NotImplementedException();
		}

		public void Start()
		{
			throw new NotImplementedException();
		}

		public string GetRandomOpponent()
		{
			throw new NotImplementedException();
		}

		public List<string> GetAllOpponents()
		{
			throw new NotImplementedException();
		}
	}
}

