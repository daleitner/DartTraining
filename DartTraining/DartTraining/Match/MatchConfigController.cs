using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DartTraining.Services;
using DartTraining.Switcher;

namespace DartTraining.Match
{
	public class MatchConfigController : IMatchConfigController
	{
		private readonly IContextSwitcher contextSwitcher;
		private readonly IDataBaseService dataBaseService;

		public MatchConfigController(IContextSwitcher contextSwitcher, IDataBaseService dataBase)
		{
			this.contextSwitcher = contextSwitcher;
			this.dataBaseService = dataBase;
		}

		public void Back()
		{
			this.contextSwitcher.OpenMainMenu();
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
			return this.dataBaseService.GetOpponents();
		}
	}
}

