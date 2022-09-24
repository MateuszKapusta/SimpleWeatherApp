using SimpleWeatherApp.Core.Models.Menu.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<CountryInfoDto> _countryInfo;
        public ObservableCollection<CountryInfoDto> CountryInfo
        {
            get { return _countryInfo; }
            set
            {
                _countryInfo = value;
                RaisePropertyChanged(() => CountryInfo);
            }
        }

        public override void Prepare()
        {
            base.Prepare();

            MockCountryInfo();
        }

        private void MockCountryInfo()
        {
            CountryInfo = new ObservableCollection<CountryInfoDto>()
            {
                new CountryInfoDto(){Name ="Test", Country="US", Lat = 42.9834, Lot = -0.1257 },
                new CountryInfoDto(){Name = "Home",Country="PL", Lat = 42.9834, Lot = 34 },
                new CountryInfoDto(){Name = "Mosk", Country = "RUS", Lat = 45, Lot = -81.233}
            };
        }

    }
}
