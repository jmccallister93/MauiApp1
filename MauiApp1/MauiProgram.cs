using Microsoft.Extensions.Logging;
using System.ComponentModel;

// Define a namespace for the code which helps organize and provide a level of separation for the classes.
namespace MauiApp1
{
    // Define a static class for creating the MAUI app. Static means the class cannot be instantiated.
    public static class MauiProgram
    {
        // Define a static method that sets up and returns a new MAUI app instance.
        public static MauiApp CreateMauiApp()
        {
            // Create a builder for the MAUI app using a fluent API.
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>() // Specify the startup class for the app.
                .ConfigureFonts(fonts =>
                {
                    // Add custom fonts to the app.
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Add debug logging if the app is built in Debug mode (useful for development).
#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Build the MAUI app instance and return it.
            return builder.Build();
        }
    }

    // Define a class for to-do items that notifies when its properties change.
    public class ToDoItem : INotifyPropertyChanged
    {
        // Public property for the to-do item description. 'Public' means it can be accessed from outside the class.
        public string Description { get; set; }

        // Private field to back the IsCompleted property. 'Private' means it can only be accessed within this class.
        private bool _isCompleted;

        // Public property for the completion status of the to-do item.
        public bool IsCompleted
        {
            get => _isCompleted; // Getter returns the value of the private field.
            set
            {
                // Setter updates the value and raises the PropertyChanged event if the value has changed.
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted)); // Call the method to notify about the property change.
                }
            }
        }

        // Event that is raised when a property value changes. Part of implementing INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise the PropertyChanged event. 'Protected' means it can be accessed within this class and derived classes.
        // 'Virtual' means it can be overridden by derived classes.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Raise the event and pass the name of the property that changed.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
