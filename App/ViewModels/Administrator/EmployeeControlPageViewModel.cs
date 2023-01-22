using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class EmployeeControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeeControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ObservableCollection<Employee> Employees { get; set; }

    private Employee _selectedValue;
    private Employee SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
         
            if (value == null) return;
            LastName = value.LastName!;
            FirstName = value.FirstName!;
            Email = value.Email!;
        }
    }
    
    private string? FirstName { get; set; }
    private string? LastName { get; set; }
    private string? Email { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public EmployeeControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Employees = new ObservableCollection<Employee>(Db.Employees!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }

    private void Insert()
    {
        Employee inserting = new Employee()
        {
            LastName = LastName,
            FirstName = FirstName,
            Email = Email
        };
        try
        {
            Db.Employees!.Add(inserting);
            Db.SaveChanges();
            Employees.Add(inserting);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        try
        {
            Db.Employees!.Update(SelectedValue);
            Db.SaveChanges();
            SelectedValue.LastName = LastName;
            SelectedValue.FirstName = FirstName;
            SelectedValue.Email = Email;
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Employees.Clear();
        Employees = new ObservableCollection<Employee>(Db.Employees!);
    }

    private void Delete()
    {
        try
        {
            Db.Employees!.Remove(SelectedValue);
            Db.SaveChanges();
            Employees.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    