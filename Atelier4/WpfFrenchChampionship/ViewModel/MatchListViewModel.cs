using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SoccerRankingLib;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfFrenchChampionship.ViewModel
{
    public class MatchListViewModel : ViewModel
    {
        private ObservableCollection<Match> _matches;
        private Ranking _ranking;

        public MatchListViewModel(Ranking ranking)
        {
            this._matches = new ObservableCollection<Match>();
            this._ranking = ranking;
            this._ranking.NewMatchRegistered += new EventHandler<Ranking.MatchRegistrationEventArgs>(_ranking_NewMatchRegistered);
        }

        void _ranking_NewMatchRegistered(object sender, Ranking.MatchRegistrationEventArgs e)
        {
            Match newMatch = new Match(e.NewMatch.Home, e.NewMatch.Away,e.NewMatch.HomeGoals, e.NewMatch.AwayGoals);
            this._matches.Add(newMatch);
            RaisePropertyChanged("Matches");
        }

        public ObservableCollection<Match> Matches
          {
              get { return this._matches; }
          } 
    }
}
