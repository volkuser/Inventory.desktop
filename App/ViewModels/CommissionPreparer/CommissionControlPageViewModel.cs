using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Commission> Commissions { get; set; }

    private Commission _selectedValue;
    private Commission SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            
            if (value == null) return;
            CommissionFormationDate = new DateTimeOffset(value.CommissionFormationDate);
        }
    }
    
    private DateTimeOffset CommissionFormationDate { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public CommissionControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Commissions = new ObservableCollection<Commission>(Db.Commissions!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        Commission inserting = new Commission()
        {
            CommissionFormationDate = CommissionFormationDate.Date
        };
        try
        {
            Db.Commissions!.Add(inserting);
            Db.SaveChanges();
            Commissions.Add(inserting);
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
            SelectedValue.CommissionFormationDate = CommissionFormationDate.Date;
            Db.Commissions!.Update(SelectedValue);
            Db.SaveChanges();
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Commissions.Clear();
        Commissions = new ObservableCollection<Commission>(Db.Commissions!);
    }

    private void Delete()
    {
        try
        {
            Db.Commissions!.Remove(SelectedValue);
            Db.SaveChanges();
            Commissions.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    