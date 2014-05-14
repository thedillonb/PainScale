using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PainScale.iOS.Services;
using System.Collections.Generic;
using PainScale.iOS.Models;

namespace PainScale.iOS.ViewControllers
{
    public partial class QuestionnaireViewController : UIViewController
    {
        private readonly List<ReasonModel> _reasons = new List<ReasonModel>();
        private readonly Dictionary<int, object> _selected = new Dictionary<int, object>();

        public QuestionnaireViewController() 
            : base("QuestionnaireViewController", null)
        {
            Title = "When did the Pain Start?";
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(Images.BackButton, UIBarButtonItemStyle.Plain, (s, e) => NavigationController.PopViewControllerAnimated(true));
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new TableSource(this);

            Button.SetTitleColor(UIColor.White, UIControlState.Normal);
            Button.SetBackgroundImage(Images.BlueButton.CreateResizableImage(new UIEdgeInsets(18, 18, 18, 18)), UIControlState.Normal);
            Button.SetBackgroundImage(Images.BlueButtonHighlight.CreateResizableImage(new UIEdgeInsets(18, 18, 18, 18)), UIControlState.Highlighted);
            Button.TouchUpInside += (sender, e) => DismissViewController(true, null);

            var reasons = await ApplicationService.Instance.RetrieveReasons();
            _reasons.AddRange(reasons);
            TableView.ReloadData();
        }

        private class TableSource : UITableViewSource
        {
            private readonly QuestionnaireViewController _parent;

            public TableSource(QuestionnaireViewController parent)
            {
                _parent = parent;
            }

            public override int RowsInSection (UITableView tableview, int section)
            {
                return _parent._reasons.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell("reason_cell") ?? new UITableViewCell(UITableViewCellStyle.Default, "reason_cell");
                cell.TextLabel.Text = _parent._reasons[indexPath.Row].Title;
                cell.Accessory = _parent._selected.ContainsKey(indexPath.Row) ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (_parent._selected.ContainsKey(indexPath.Row))
                    _parent._selected.Remove(indexPath.Row);
                else
                    _parent._selected[indexPath.Row] = true;

                tableView.ReloadRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                //tableView.DeselectRow(indexPath, true);
            }
        }
    }
}

