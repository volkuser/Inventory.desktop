using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class InventoryControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventoryControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Inventory> Inventories { get; set; }
    
    private List<Commission> Commissions { get; set; }

    private Inventory _selectedValue;
    private Inventory SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            EventDate = new DateTimeOffset(value.EventDate);
            Commission = value.Commission;
        }
    }
    
    private DateTimeOffset EventDate { get; set; }
    private Commission? Commission { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public InventoryControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Inventories = new ObservableCollection<Inventory>(Db.Inventories!);

        Commissions = new List<Commission>(Db.Commissions!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        Inventory inserting = new Inventory()
        {
            EventDate = EventDate.Date,
            Commission = Commission
        };
        try
        {
            Db.Inventories!.Add(inserting);
            Db.SaveChanges();
            Inventories.Add(inserting);
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
            SelectedValue.EventDate = EventDate.Date;
            Db.Inventories!.Update(SelectedValue);
            Db.SaveChanges();
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Inventories.Clear();
        Inventories = new ObservableCollection<Inventory>(Db.Inventories!);
    }

    private void Delete()
    {
        try
        {
            Db.Inventories!.Remove(SelectedValue);
            Db.SaveChanges();
            Inventories.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    