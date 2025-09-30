using System.ComponentModel;

namespace WPF_TODOAPP.Models
{
    public class ToDoEntity : INotifyPropertyChanged
    {
        private bool _isDone;

        public ToDoEntity(string title, bool isDone = false)
        {
            IsDone = isDone;
            Title = title;
        }

        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
            }
        }
        public string Title { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString() => Title;
    }
}
