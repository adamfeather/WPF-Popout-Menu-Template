using GalaSoft.MvvmLight.Command;
using PopoutMenuTest.AddressBook;
using PopoutMenuTest.Calendar;
using PopoutMenuTest.Home;
using PopoutMenuTest.Settings;
using PopoutMenuTest.Utility;
using System.Windows;
using System.Windows.Input;

namespace PopoutMenuTest
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly HomeViewModel _homeViewModel = new HomeViewModel();
        private readonly AddressBookViewModel _addressBookViewModel = new AddressBookViewModel();
        private readonly CalendarViewModel _calendarViewModel = new CalendarViewModel(); 
        private readonly SettingsViewModel _settingsViewModel = new SettingsViewModel();
        private ViewModel _viewModelToDisplay;

        public ViewModel ViewModelToDisplay
        {
            get => _viewModelToDisplay;
            set
            {
                if (Equals(value, _viewModelToDisplay)) return;
                _viewModelToDisplay = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NavigateToHomeCommand { get; private set; }

        public ICommand NavigateToAddressBookCommand { get; private set; }

        public ICommand NavigateToCalendarCommand { get; private set; }

        public ICommand NavigateToSettingsCommand { get; private set; }

        public ICommand ExitApplicationCommand { get; private set; }

        public MainWindowViewModel()
        {
            Display(_homeViewModel);

            ConfigureCommands();
        }

        private void Display(ViewModel viewModel)
        {
            ViewModelToDisplay = viewModel;
        }

        private void ConfigureCommands()
        {
            NavigateToHomeCommand = new RelayCommand(OnNavigateToHomeCommand);

            NavigateToAddressBookCommand = new RelayCommand(OnNavigateToAddressBookCommand);

            NavigateToCalendarCommand = new RelayCommand(OnNavigateToCalendarCommand);

            NavigateToSettingsCommand = new RelayCommand(OnNavigateToSettingsCommand);

            ExitApplicationCommand = new RelayCommand(OnExitApplicationCommand);
        }

        private void OnExitApplicationCommand()
        {
            Application.Current.Shutdown(0);
        }

        private void OnNavigateToSettingsCommand()
        {
            Display(_settingsViewModel);
        }

        private void OnNavigateToCalendarCommand()
        {
            Display(_calendarViewModel);
        }

        private void OnNavigateToAddressBookCommand()
        {
         Display(_addressBookViewModel);   
        }

        private void OnNavigateToHomeCommand()
        {
            Display(_homeViewModel);
        }
    }
}
