// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace PainScale.iOS.ViewControllers
{
	[Register ("ScaleViewController")]
	partial class ScaleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton Button { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NumberLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider Slider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (NumberLabel != null) {
				NumberLabel.Dispose ();
				NumberLabel = null;
			}

			if (Slider != null) {
				Slider.Dispose ();
				Slider = null;
			}

			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}
		}
	}
}
