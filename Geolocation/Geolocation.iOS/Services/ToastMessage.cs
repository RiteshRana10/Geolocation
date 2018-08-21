using System;
using Foundation;
using Geolocation.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace Geolocation.iOS
{
    public class ToastMessage : IToast
        {
            const double DELAY = 3.5;
            NSTimer alertDelay;
            UIAlertController alert;


            public void Place(string message)
            {
                ShowAlert(message, DELAY);
            }
            void ShowAlert(string message, double seconds)
            {
                alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
                {
                    dismissMessage();
                });
                alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
            }

            void dismissMessage()
            {
                if (alert != null)
                {
                    alert.DismissViewController(true, null);
                }
                if (alertDelay != null)
                {
                    alertDelay.Dispose();
                }
            }

        }
    }

