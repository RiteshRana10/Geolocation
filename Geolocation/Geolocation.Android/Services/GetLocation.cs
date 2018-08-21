using System;
using Android.Locations;
using Android.Content;
using Geolocation.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation))]
namespace Geolocation.Droid
{
       
        public class LocationEventArgs : EventArgs, ILocationEventArgs
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class GetLocation : Java.Lang.Object,
                                    ILocation,
                                    ILocationListener
        {
            LocationManager lm;
            public void OnProviderDisabled(string provider) { }
            public void OnProviderEnabled(string provider) { }
            public void OnStatusChanged(string provider,
                Availability status, Android.OS.Bundle extras)
            { }
            
            public void OnLocationChanged(Location location)
            {
                if (location != null)
                {
                    LocationEventArgs args = new LocationEventArgs();
                    args.lat = location.Latitude;
                    args.lng = location.Longitude;
                    locationObtained(this, args);
                };
            }
       
            public event EventHandler<ILocationEventArgs>
                locationObtained;
           
            event EventHandler<ILocationEventArgs>
                ILocation.locationObtained
            {
                add
                {
                    locationObtained += value;
                }
                remove
                {
                    locationObtained -= value;
                }
            }
           
            public void ObtainMyLocation()
            {
                lm = (LocationManager)
                    Forms.Context.GetSystemService(
                        Context.LocationService);
                lm.RequestLocationUpdates(
                    LocationManager.NetworkProvider,
                        0,   //---time in ms---
                        0,   //---distance in metres---
                        this);
            }
           
        ~GetLocation()
            {
                lm.RemoveUpdates(this);
            }
        }

}
