using System;
using Android.App;
using Android.Widget;
using Geolocation.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace Geolocation.Droid
{
    public class ToastMessage : IToast
    {
        public void Place(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
    }
