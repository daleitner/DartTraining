using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Base;

namespace DartTraining.Match
{
	public class MatchConfigViewModel : ViewModelBase
	{
		private int scores;
		private int sets;
		private int legs;
		private List<string> opponents;
		private string selectedOpponent;
		private bool isCPU;
		private RelayCommand randomCommand;
		private List<object> levels;
		private object selectedLevel;
		private RelayCommand backCommand;
		private RelayCommand startCommand;
		private string player;
		private bool isPlayer;
		private bool isSetBestOf;
		private bool isLegBestOf;
		private readonly IMatchConfigController controller;
		public MatchConfigViewModel(IMatchConfigController controller)
		{
			this.controller = controller;
			this.opponents = this.controller.GetAllOpponents();
			this.levels = new List<object>();
			SetDefaultValues();
		}

		private void SetDefaultValues()
		{
			this.Scores = 501;
			this.Sets = 1;
			this.Legs = 5;
			this.IsLegBestOf = true;
			this.IsCPU = true;
		}

		public int Scores
		{
			get
			{
				return this.scores;
			}
			set
			{
				this.scores = value;
				OnPropertyChanged(nameof(this.Scores));
			}
		}

		public int Sets
		{
			get
			{
				return this.sets;
			}
			set
			{
				this.sets = value;
				OnPropertyChanged(nameof(this.Sets));
			}
		}

		public int Legs
		{
			get
			{
				return this.legs;
			}
			set
			{
				this.legs = value;
				OnPropertyChanged(nameof(this.Legs));
			}
		}

		public List<string> Opponents
		{
			get
			{
				return this.opponents;
			}
			set
			{
				this.opponents = value;
				OnPropertyChanged(nameof(this.Opponents));
			}
		}

		public string SelectedOpponent
		{
			get
			{
				return this.selectedOpponent;
			}
			set
			{
				this.selectedOpponent = value;
				OnPropertyChanged(nameof(this.SelectedOpponent));
			}
		}

		public bool IsCPU
		{
			get
			{
				return this.isCPU;
			}
			set
			{
				this.isCPU = value;
				OnPropertyChanged(nameof(this.IsCPU));
			}
		}

		public ICommand RandomCommand
		{
			get
			{
				return this.randomCommand ?? (this.randomCommand = new RelayCommand(param => Random(), param => this.IsCPU));
			}
		}

		public List<object> Levels
		{
			get
			{
				return this.levels;
			}
			set
			{
				this.levels = value;
				OnPropertyChanged(nameof(this.Levels));
			}
		}

		public object SelectedLevel
		{
			get
			{
				return this.selectedLevel;
			}
			set
			{
				this.selectedLevel = value;
				OnPropertyChanged(nameof(this.SelectedLevel));
			}
		}

		public ICommand BackCommand
		{
			get
			{
				return this.backCommand ?? (this.backCommand = new RelayCommand(param => Back()));
			}
		}

		public ICommand StartCommand
		{
			get
			{
				return this.startCommand ?? (this.startCommand = new RelayCommand(param => Start()));
			}
		}

		public string Player
		{
			get
			{
				return this.player;
			}
			set
			{
				this.player = value;
				OnPropertyChanged(nameof(this.Player));
			}
		}

		public bool IsPlayer
		{
			get
			{
				return this.isPlayer;
			}
			set
			{
				this.isPlayer = value;
				OnPropertyChanged(nameof(this.IsPlayer));
			}
		}

		public bool IsSetBestOf
		{
			get { return this.isSetBestOf; }
			set
			{
				this.isSetBestOf = value;
				OnPropertyChanged(nameof(this.IsSetBestOf));
			}
		}

		public bool IsLegBestOf
		{
			get { return this.isLegBestOf; }
			set
			{
				this.isLegBestOf = value;
				OnPropertyChanged(nameof(this.IsLegBestOf));
			}
		}

		private void Random()
		{
			this.SelectedOpponent = this.controller.GetRandomOpponent();
		}

		private void Back()
		{
			this.controller.Back();
		}

		private void Start()
		{
			this.controller.Start();
		}

	}
}
