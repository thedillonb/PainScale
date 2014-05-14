using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PainScale.iOS.ViewControllers;

namespace PainScale.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var historyViewController = new HistoryViewController { Title = "Pain Scale" };
            historyViewController.NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Compose, (s, e) => PresentPainScale(historyViewController));

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UINavigationController(historyViewController);
            Window.MakeKeyAndVisible();
            return true;
        }

        private void PresentPainScale(UIViewController viewController)
        {
            viewController.PresentViewController(new UINavigationController(new ScaleViewController()), true, null);
        }
    }
}

