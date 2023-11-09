using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    class ToDoListViewModel : INotifyPropertyChanged
    {
        // Collection of ToDoItems that the UI will bind to.
        public ObservableCollection<ToDoItem> Items { get; } = new ObservableCollection<ToDoItem>();

        private string _newItemDescription;
        public string NewItemDescription
        {
            get => _newItemDescription;
            set
            {
                if (_newItemDescription != value)
                {
                    _newItemDescription = value;
                    OnPropertyChanged(nameof(NewItemDescription));
                }
            }
        }

        // Command that will be executed when the add button is clicked.
        public ICommand AddItemCommand { get; }

        public ToDoListViewModel() 
        {
            AddItemCommand = new Command(AddItem);
        }
        private void AddItem()
        {
            if (!string.IsNullOrEmpty(NewItemDescription))
            {
                // Add a new ToDoItem to the collection with the given description.
                Items.Add(new ToDoItem { Description = NewItemDescription });
                // Clear the input field after adding the item.
                NewItemDescription = string.Empty;
            }

        }
        // Implementation of INotifyPropertyChanged to update the UI on property changes.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
