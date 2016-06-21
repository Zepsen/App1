using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class TrailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Trail _trails { get; set; }
        public TrailsViewModel()
        {
            _trails = new Trail();
        }

        public string Name
        {
            get
            {
                return _trails.Name;
            }
            set
            {
                _trails.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string GetTrails()
        {
            //var res = DbQueryAsync.GetDataFromRestTestCtrl();
            return "Test2";//res.Result;
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
