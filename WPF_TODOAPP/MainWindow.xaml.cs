using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_TODOAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (this.Content as Grid).MouseLeftButtonDown += (s, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            };

            ToDoListBox.MouseDoubleClick += (s, e) =>
            {

            };
        }
    }
}