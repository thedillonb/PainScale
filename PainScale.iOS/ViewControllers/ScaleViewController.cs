using System;
using MonoTouch.UIKit;

namespace PainScale.iOS.ViewControllers
{
    public partial class ScaleViewController : UIViewController
    {
        public ScaleViewController() 
            : base("ScaleViewController", null)
        {
            Title = "What Is Your Level of Pain?";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Button.SetTitleColor(UIColor.White, UIControlState.Normal);
            Button.SetBackgroundImage(Images.BlueButton.CreateResizableImage(new UIEdgeInsets(18, 18, 18, 18)), UIControlState.Normal);
            Button.SetBackgroundImage(Images.BlueButtonHighlight.CreateResizableImage(new UIEdgeInsets(18, 18, 18, 18)), UIControlState.Highlighted);
            Button.TouchUpInside += (sender, e) => NavigationController.PushViewController(new QuestionnaireViewController(), true);

            Slider.MaxValue = 10;
            Slider.MinValue = 0;
            Slider.Value = Slider.MinValue;
            Slider.ValueChanged += (sender, e) =>
            {
                var value = Math.Round(Slider.Value);
                Slider.Value = (float)value;
                NumberLabel.Text = value.ToString();
                SelectFace();
            };

            NumberLabel.Text = Slider.Value.ToString();
            SelectFace();
        }


        private void SelectFace()
        {
            UIImage img;
            if (Slider.Value < 2)
                img = Images.HappyFace;
            else if (Slider.Value < 5)
                img = Images.NeutralFace;
            else if (Slider.Value < 8)
                img = Images.SadFace;
            else
                img = Images.DeadFace;

            ImageView.Image = img;
        }
    }
}

