using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Validator;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu;

public class MenuViewModel : ObservableObject
{
    //Fields
    private readonly INavigationService _navigationService;
    
    //Commands
    public ICommand NavigateCommand { get; set; }
    
    public MenuViewModel()
    {
        NavigateCommand = new RelayCommand(NavigationExecute);
        _navigationService = new CustomNavigationService();
        _navigationService.NavigateTo(new ValidatorViewModel());
    }

    //Command Handlers
    private void NavigationExecute(object? obj)
    {
        if (obj is string destination)
        {
            switch (destination)
            {
                case "Passwords":
                    NavigateToPasswords();
                    break;
                case "Categories":
                    NavigateToCategories();
                    break;
                case "ImportExport":
                    NavigateToImportExport();
                    break;
                case "Validator":
                    NavigateToValidator();
                    break;
                default:
                    NavigateToPasswords();
                    break;
            }
        }
    }

    // Navigation Methods
    private void NavigateToPasswords()
    {
        _navigationService.NavigateTo(new PasswordsViewModel());
    }
    private void NavigateToCategories()
    {
        _navigationService.NavigateTo(new CategoriesViewModel());
    }
    private void NavigateToImportExport()
    {
        _navigationService.NavigateTo(new ImportExportViewModel());
    }
    private void NavigateToValidator()
    {
        _navigationService.NavigateTo(new ValidatorViewModel());
    }
}