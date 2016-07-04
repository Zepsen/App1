using App1.Models;
using App1.Models.HelperModel;
using App1.Views.TrailPage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class OptionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;    
        public UpdatedOptionModel _option { get; set; }
        private string _trailId;

        private Dictionary<string, string> SeasonStartDictionary;
        private Dictionary<string, string> SeasonEndDictionary;
        private Dictionary<string, string> TrailTypeDictionary;
        private Dictionary<string, string> TrailDurationTypeDictionary;

        public OptionViewModel(string trailId, Option option)
        {
            _trailId = trailId;
            _option = new UpdatedOptionModel
            {
                DurationType = "",
                Type = "",
                SeasonStart = "",
                SeasonEnd = ""
            };

            foreach (var season in option.Seasons)
            {
                SeasonStartDictionary.Add(season.Id, season.Value);
            }

            foreach (var season in option.Seasons)
            {
                SeasonEndDictionary.Add(season.Id, season.Value);
            }

            foreach (var season in option.TrailsTypes)
            {
                TrailTypeDictionary.Add(season.Id, season.Value);
            }

            foreach (var season in option.TrailsDurationTypes)
            {
                TrailDurationTypeDictionary.Add(season.Id, season.Value);
            }
        }


        public double Distance
        {
            get
            {
                return _option.Distance;
            }
            set
            {
                _option.Distance = value;
                OnPropertyChanged(nameof(_option.Distance));
            }
        }
        public const string DistanceCommandPropertyName = "Distance";
        public int Peak
        {
            get
            {
                return _option.Peak;
            }
            set
            {
                _option.Peak = value;
                OnPropertyChanged(nameof(_option.Peak));
            }
        }
        public const string PeakCommandPropertyName = "Peak";
        public double Elevation
        {
            get
            {
                return _option.Elevation;
            }
            set
            {
                _option.Elevation = value;
                OnPropertyChanged(nameof(_option.Elevation));
            }
        }
        public const string ElevationCommandPropertyName = "Elevation";
        public string SeasonStart
        {
            get
            {
                return _option.SeasonStart;
            }
            set
            {
                _option.SeasonStart = SeasonStartDictionary.First(i => i.Value == value).Key;
                OnPropertyChanged(nameof(_option.SeasonStart));
            }
        }
        public const string SeasonStartCommandPropertyName = "SeasonStart";
        public string SeasonEnd
        {
            get
            {
                return _option.SeasonEnd;
            }
            set
            {
                _option.SeasonEnd = value;
                OnPropertyChanged(nameof(_option.SeasonEnd));
            }
        }
        public const string SeasonEndCommandPropertyName = "SeasonEnd";
        public bool DogAllowed
        {
            get
            {
                return _option.DogAllowed;
            }
            set
            {
                _option.DogAllowed = value;
                OnPropertyChanged(nameof(_option.DogAllowed));
            }
        }
        public const string DogAllowedCommandPropertyName = "DogAllowed";
        public bool GoodForKids
        {
            get
            {
                return _option.GoodForKids;
            }
            set
            {
                _option.GoodForKids = value;
                OnPropertyChanged(nameof(_option.GoodForKids));
            }
        }
        public const string GoodForKidsCommandPropertyName = "GoodForKids";
        public string Type
        {
            get
            {
                return _option.Type;
            }
            set
            {
                _option.Type = value;
                OnPropertyChanged(nameof(_option.Type));
            }
        }
        public const string TypeCommandPropertyName = "Type";
        public string DurationType
        {
            get
            {
                return _option.DurationType;
            }
            set
            {
                _option.DurationType = value;
                OnPropertyChanged(nameof(_option.DurationType));
            }
        }
        public const string DurationTypeCommandPropertyName = "DurationType";

        private Command updateCommand;
        public const string  UpdateCommandPropertyName = "UpdateCommand";
        public Command UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new Command(async () => await ExecuteUpdateCommand()));
            }
        }

        private async Task<FullTrail> ExecuteUpdateCommand()
        {
            var res = DbQueryAsync.UpdateOption(_trailId, _option);
            return res;
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
