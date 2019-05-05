using System;
using System.Windows;
using Base;

namespace DartTraining.Match
{
	public class StatisticViewModel : ViewModelBase
	{
		#region members
		private string _name = "";
		private int _sets;
		private int _legs;
		private int _hundrets;
		private int _hundretFourties;
		private int _hundretSeventies;
		private double _average;
		private int _tries = 0;
		private int _hits = 0;
		private Visibility _showStatisticsVisibility = Visibility.Collapsed;
		#endregion

		#region ctors
		public StatisticViewModel(string name)
		{
			Name = name;
		}
		#endregion

		#region properties
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		public int Sets
		{
			get
			{
				return _sets;
			}
			set
			{
				_sets = value;
				OnPropertyChanged(nameof(Sets));
			}
		}
		public int Legs
		{
			get
			{
				return _legs;
			}
			set
			{
				_legs = value;
				OnPropertyChanged(nameof(Legs));
			}
		}
		public int Hundrets
		{
			get
			{
				return _hundrets;
			}
			set
			{
				_hundrets = value;
				OnPropertyChanged(nameof(Hundrets));
			}
		}
		public int HundretFourties
		{
			get
			{
				return _hundretFourties;
			}
			set
			{
				_hundretFourties = value;
				OnPropertyChanged(nameof(HundretFourties));
			}
		}
		public int HundretSeventies
		{
			get
			{
				return _hundretSeventies;
			}
			set
			{
				_hundretSeventies = value;
				OnPropertyChanged(nameof(HundretSeventies));
			}
		}
		public double Average
		{
			get
			{
				return _average;
			}
			set
			{
				_average = value;
				OnPropertyChanged(nameof(Average));
			}
		}

		public double DoubleQuote => _tries > 0 ? Math.Round((double) _hits / _tries * 100, 2) : 0.0;

		public string Doubles => "(" + _hits + " / " + _tries + ")";

		public Visibility ShowStatisticsVisibility
		{
			get
			{
				return _showStatisticsVisibility;
			}
			set
			{
				_showStatisticsVisibility = value;
				OnPropertyChanged(nameof(ShowStatisticsVisibility));
			}
		}
		#endregion

		#region private methods
		#endregion
	}
}
