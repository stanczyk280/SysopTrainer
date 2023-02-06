using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SysopTrainer.Behaviors
{
    public class ButtonEnlarge : Behavior<Button>
    {
        public double OldHeight { get; set; }
        public double OldWidth { get; set; }

        protected override void OnAttached()
        {
            Button button = AssociatedObject;
            if (button != null)
            {
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
        }

        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            OldHeight = button.Height;
            OldWidth = button.Width;
            button.Height *= 1.1;
            button.Width *= 1.1;
        }

        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            button.Height = OldHeight;
            button.Width = OldWidth;
        }

        protected override void OnDetaching()
        {
            Button button = AssociatedObject;
            if (button != null)
            {
                button.MouseEnter -= Button_MouseEnter;
                button.MouseLeave -= Button_MouseLeave;
            }
        }
    }
}