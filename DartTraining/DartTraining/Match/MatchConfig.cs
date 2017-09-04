using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartTraining.Match
{
	public class MatchConfig
	{
		public MatchConfig(int points, int sets, bool bestOfSets, int legs, bool bestOfLegs, string opponent, bool isPlayer, int level)
		{
			this.Points = points;
			this.Sets = sets;
			this.BestOfSets = bestOfSets;
			this.Legs = legs;
			this.BestOfLegs = bestOfLegs;
			this.Opponent = opponent;
			this.IsPlayer = isPlayer;
			this.Level = level;
		}

		public int Points { get; set; }
		public int Sets { get; set; }
		public bool BestOfSets { get; set; }
		public int Legs { get; set; }
		public bool BestOfLegs { get; set; }
		public string Opponent { get; set; }
		public bool IsPlayer { get; set; }
		public int Level { get; set; }

		public override string ToString()
		{
			var str = "Points: " + this.Points + "\r\n";
			str += "Sets: " + this.Sets + "\r\n";
			str += "Legs: " + this.Legs + "\r\n";
			str += "BestOfSets: " + this.BestOfSets + "\r\n";
			str += "BestOfLegs: " + this.BestOfLegs + "\r\n";
			str += "Opponent: " + this.Opponent + "\r\n";
			str += "IsPlayer: " + this.IsPlayer + "\r\n";
			str += "Level: " + this.Level;
			return str;
		}
	}
}
