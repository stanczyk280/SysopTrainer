using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SysopTrainer.Behaviors
{
    public class WindowClose : Behavior<Window>
    {
        public Key Key { get; set; }

        protected override void OnAttached()
        {
            Window window = AssociatedObject;
            if (window != null) window.PreviewKeyDown += window_PreviewKeyDown;
        }

        public void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var window = (Window)sender;
            if (e.Key == Key)
            {
                window.Close();
            }
        }
    }
}