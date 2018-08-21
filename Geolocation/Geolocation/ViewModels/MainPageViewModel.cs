using Geolocation.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Geolocation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Location location;

        ILocation loc;
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Location Finder";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {

            loc = Xamarin.Forms.DependencyService.Get<ILocation>();
            loc.locationObtained += (object sender,
                ILocationEventArgs e) => {
                    var lat = e.lat;
                    var lng = e.lng;
                    location = new Location()
                    {
                    Lat = lat.ToString(),
                    Lng = lng.ToString()
                    };
                };
            loc.ObtainMyLocation(); 

        }

        public override void Destroy()
        {
          Xamarin.Forms.DependencyService.Get<IToast>().Place("latitude and longitude is" + location.Lat + location.Lng); 
        }
    }
}
