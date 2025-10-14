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
            RefreshList();
        }

        private void AddNewToDo(object sender, RoutedEventArgs e)
        {
            newTodoWindow = new(ContextManager);
            newTodoWindow.Closed += (s, e) =>
            {
                RefreshList();
            };
            newTodoWindow.ShowDialog();
        }

        private void RemoveSelectedTodo(object sender, RoutedEventArgs e)
        {
            ToDoEntity? Selected = ToDoListBox.SelectedItem as ToDoEntity;
            if (Selected != null)
            {
                ContextManager.Remove(Selected);
                RefreshList();
            }
        }

        private void RefreshList()
        {
            ToDoListBox.ItemsSource = null;
            ToDoListBox.ItemsSource = ContextManager.GetAll();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            int id = (int)cbox.DataContext;
            ToDoEntity? Upgradable = ContextManager.GetById(id);

            if (Upgradable != null)
            {
                Upgradable.IsDone = cbox.IsChecked.Value;
                ContextManager.Update(Upgradable);
            }
        }
    }
}