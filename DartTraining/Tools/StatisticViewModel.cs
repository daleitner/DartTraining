using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Base;

namespace :.Users.MCLeite.Documents.Projects.Darttraining.DartTraining.DartTraining.Match
{
	public class StatisticViewModel : ViewModelBase
	{
		#region members
		private string _name = "";
		private string _sets = "";
		private string _legs = "";
		private string _hundrets = "";
		private string _hundretFourties = "";
		private string _hundretSeventies = "";
		private string _average = "";
		private string _doubleQuote = "";
		private string _doubles = "";
		private Visibility _showStatisticsVisibility = Visibility.Collapsed;
		#endregion

		#region ctors
		public StatisticViewModel()
		{
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
		public string Sets
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
		public string Legs
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
		public string Hundrets
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
		public string HundretFourties
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
		public string HundretSeventies
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
		public string Average
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
		public string DoubleQuote
		{
			get
			{
				return _doubleQuote;
			}
			set
			{
				_doubleQuote = value;
				OnPropertyChanged(nameof(DoubleQuote));
			}
		}
		public string Doubles
		{
			get
			{
				return _doubles;
			}
			set
			{
				_doubles = value;
				OnPropertyChanged(nameof(Doubles));
			}
		}
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
