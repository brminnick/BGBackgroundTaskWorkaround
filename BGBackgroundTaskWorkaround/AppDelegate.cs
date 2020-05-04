using System;
using Foundation;
using UIKit;

namespace BGBackgroundTaskWorkaround
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow? Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);
            return true;
        }

        public override async void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            var alertController = new UIAlertController
            {
                Title = "Background Fetch Triggered",
                Message = "It's working!",
            };

            var currentViewController = Xamarin.Essentials.Platform.GetCurrentUIViewController();

            await currentViewController.PresentViewControllerAsync(alertController, true);

            completionHandler(UIBackgroundFetchResult.NoData);
        }
    }
}

