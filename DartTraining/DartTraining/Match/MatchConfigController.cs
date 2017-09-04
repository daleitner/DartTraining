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

		public void Start(MatchConfig config)
		{
			this.contextSwitcher.StartMatch(config);
		}

		public string GetRandomOpponent(List<string> opponents)
		{
			var rnd = new Random();
			return opponents[rnd.Next(opponents.Count)];
		}

		public List<string> GetAllOpponents()
		{
			return this.dataBaseService.GetOpponents();
		}

		public List<int> GetAllLevels()
		{
			return this.dataBaseService.GetLevels();
		}
	}
}

