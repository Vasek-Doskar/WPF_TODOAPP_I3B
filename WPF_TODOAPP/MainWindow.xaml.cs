using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_TODOAPP.Database;
using WPF_TODOAPP.Models;
using WPF_TODOAPP.Windows;

namespace WPF_TODOAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContextManager ContextManager { get; set; }
        NewFileWindow newTodoWindow;
        public MainWindow()
        {
            ToDoContext context = new();
            ContextManager = new ContextManager(context);

            InitializeComponent();

            (this.Content as Grid)!.MouseLeftButtonDown += (s, e) =>
            {

                if (e.ChangedButton == MouseButton.Left)
                {
                    try
                    {
                        this.DragMove();
                    }
                    catch { }
                }
            };

            ToDoListBox.MouseDoubleClick += (s, e) =>
            {
                newTodoWindow = new(ContextManager);
                newTodoWindow.ShowDialog();
            };
        }
    }
}