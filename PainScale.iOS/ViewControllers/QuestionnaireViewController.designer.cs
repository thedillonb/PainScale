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
	[Register ("QuestionnaireViewController")]
	partial class QuestionnaireViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton Button { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}
		}
	}
}
