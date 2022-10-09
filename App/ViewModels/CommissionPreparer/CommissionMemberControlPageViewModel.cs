using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionMemberControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionMemberControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Models.CommissionMember> CommissionMembers { get; set; }
    
    private List<Commission> Commissions { get; set; }
    private List<Employee> Employees { get; set; }

    private Models.CommissionMember _selectedValue;
    public Models.CommissionMember SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            Commission = value.Commission;
            Employee = value.Employee;
        }
    }
    
    private Commission? Commission { get; set; }
    private Employee? Employee { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public CommissionMemberControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        CommissionMembers = new ObservableCollection<Models.CommissionMember>(Db.CommissionMembers!);

        Commissions = new List<Commission>(Db.Commissions!);
        Employees = new List<Employee>(Db.Employees!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        Models.CommissionMember inserting = new Models.CommissionMember()
        {
            Commission = Commission,
            Employee = Employee
        };
        CommissionMembers.Add(inserting);
        Db.CommissionMembers!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.Commission = Commission;
        SelectedValue.Employee = Employee;
        Db.CommissionMembers!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Delete()
    {
        CommissionMembers.Remove(SelectedValue);
        Db.CommissionMembers!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}