using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClosePrvotItem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<string> Items = new ObservableCollection<string>() {"One","Two","Three","Four" };
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            MyPivot.ItemsSource = Items;
        }
        public ICommand ItemCommand
        {
            get
            {
                return new CommadEventHandler<string>((item) => ItemClick(item));
            }
        }
        private void ItemClick(string item)
        {
            Items.Remove(item);
        }    
    }

    class CommadEventHandler<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<T> action;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
        public CommadEventHandler(Action<T> action)
        {
            this.action = action;

        }
    }
}
