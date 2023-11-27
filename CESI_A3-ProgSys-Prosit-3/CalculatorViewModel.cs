using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action _execute;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _execute?.Invoke();
    }
}

public class CalculatorViewModel : INotifyPropertyChanged
{
    private CalculatorModel _calculatorModel = new CalculatorModel();
    private string _selectedOperation = string.Empty;

    public CalculatorViewModel()
    {
        // Utilisez l'opérateur de coalescence nulle pour garantir que la valeur n'est pas nulle
        SelectedOperation = Operations.FirstOrDefault() ?? string.Empty;
        CalculateCommand = new RelayCommand(Calculate);
    }

    public double Number1
    {
        get { return _calculatorModel.Number1; }
        set
        {
            _calculatorModel.Number1 = value;
            OnPropertyChanged(nameof(Number1));
        }
    }

    public double Number2
    {
        get { return _calculatorModel.Number2; }
        set
        {
            _calculatorModel.Number2 = value;
            OnPropertyChanged(nameof(Number2));
        }
    }

    public ObservableCollection<string> Operations { get; } = new ObservableCollection<string> { "Addition", "Subtraction", "Multiplication", "Division" };

    public string SelectedOperation
    {
        get { return _selectedOperation; }
        set
        {
            // Utilisez l'opérateur de coalescence nulle pour garantir que la valeur n'est pas nulle
            _selectedOperation = value ?? string.Empty;
            OnPropertyChanged(nameof(SelectedOperation));
        }
    }

    public double Result
    {
        get
        {
            // Utilisez l'opérateur de coalescence nulle pour garantir que la valeur n'est pas nulle
            return _calculatorModel.Calculate(SelectedOperation ?? string.Empty);
        }
    }

    public ICommand CalculateCommand { get; private set; }

    private void Calculate()
    {
        OnPropertyChanged(nameof(Result));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
