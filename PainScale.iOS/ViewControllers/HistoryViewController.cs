using MonoTouch.UIKit;
using PainScale.iOS.Models;
using System.Collections.Generic;
using PainScale.iOS.Services;
using MonoTouch.Foundation;

namespace PainScale.iOS.ViewControllers
{
    public partial class HistoryViewController : UIViewController
    {
        private readonly List<HistoryModel> _history = new List<HistoryModel>();


        public HistoryViewController() 
            : base("HistoryViewController", null)
        {
            Title = "History";
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new TableSource(this);

            var reasons = await ApplicationService.Instance.RetrieveHistory();
            _history.AddRange(reasons);
            TableView.ReloadData();
        }

        private class TableSource : UITableViewSource
        {
            private readonly HistoryViewController _parent;

            public TableSource(HistoryViewController parent)
            {
                _parent = parent;
            }

            public override int RowsInSection (UITableView tableview, int section)
            {
                return _parent._history.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell("reason_cell") ?? new UITableViewCell(UITableViewCellStyle.Value1, "reason_cell");
                cell.TextLabel.Text = _parent._history[indexPath.Row].Value.ToString();
                cell.DetailTextLabel.Text = _parent._history[indexPath.Row].Date.ToString("g");
                return cell;
            }
        }
    }
}

