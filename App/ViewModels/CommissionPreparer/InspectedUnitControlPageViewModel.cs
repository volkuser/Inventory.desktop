using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class InspectedUnitControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inspectedUnitControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<InspectedUnit> InspectedUnits { get; set; }
    
    private List<Inventory> Inventories { get; set; }
    private List<EquipmentUnit> EquipmentUnits { get; set; }

    private InspectedUnit _selectedValue;
    private InspectedUnit SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Inventory = value.Inventory;
            EquipmentUnit = value.EquipmentUnit;
        }
    }
    
    private Inventory? Inventory { get; set; }
    private EquipmentUnit? EquipmentUnit { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public InspectedUnitControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        InspectedUnits = new ObservableCollection<InspectedUnit>(Db.InspectedUnits!);

        Inventories = new List<Inventory>(Db.Inventories!);
        EquipmentUnits = new List<EquipmentUnit>(Db.EquipmentUnits!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        InspectedUnit inserting = new InspectedUnit()
        {
            Inventory = Inventory,
            EquipmentUnit = EquipmentUnit
        };
        try
        {
            Db.InspectedUnits!.Add(inserting);
            Db.SaveChanges();
            InspectedUnits.Add(inserting);
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
            SelectedValue.Inventory = Inventory;
            SelectedValue.EquipmentUnit = EquipmentUnit;
            Db.InspectedUnits!.Update(SelectedValue);
            Db.SaveChanges();
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        InspectedUnits.Clear();
        InspectedUnits = new ObservableCollection<InspectedUnit>(Db.InspectedUnits!);
    }

    private void Delete()
    {
        try
        {
            Db.InspectedUnits!.Remove(SelectedValue);
            Db.SaveChanges();
            InspectedUnits.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    