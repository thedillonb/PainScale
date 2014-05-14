using System;

// Analysis disable once CheckNamespace
using MonoTouch.UIKit;


namespace PainScale.iOS
{
    public static class Images
    {
        public static UIImage BlueButton { get { return UIImage.FromBundle("Images/blueButton"); } }
        public static UIImage BlueButtonHighlight { get { return UIImage.FromBundle("Images/blueButtonHighlight"); } }
        public static UIImage BackButton { get { return UIImage.FromBundle("Images/back"); } }

        public static UIImage HappyFace { get { return UIImage.FromBundle("Images/happy"); } }
        public static UIImage SadFace { get { return UIImage.FromBundle("Images/sad"); } }
        public static UIImage NeutralFace { get { return UIImage.FromBundle("Images/neutral"); } }
        public static UIImage DeadFace { get { return UIImage.FromBundle("Images/dead"); } }
    }
}

