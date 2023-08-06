using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextHandler.Utility
{
    class PopupManager
    {
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
