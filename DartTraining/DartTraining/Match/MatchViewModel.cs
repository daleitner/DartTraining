using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace DartTraining.Match
{
	public class MatchViewModel : ViewModelBase
	{
		private StatisticViewModel _player1Statistics;
		private StatisticViewModel _player2Statistics;

		public MatchViewModel()
		{

		}

		public StatisticViewModel Player1Statistics
		{
			get { return _player1Statistics; }
			set
			{
				_player1Statistics = value;
				OnPropertyChanged(nameof(Player1Statistics));
			}
		}

		public StatisticViewModel Player2Statistics
		{
			get { return _player2Statistics; }
			set
			{
				_player2Statistics = value;
				OnPropertyChanged(nameof(Player2Statistics));
			}
		}
	}
}
