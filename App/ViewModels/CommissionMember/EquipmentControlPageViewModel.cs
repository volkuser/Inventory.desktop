using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class EquipmentControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "equipmentControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Equipment> Equipments { get; set; }

    private List<EquipmentType> EquipmentTypes { get; set; }
    
    private Equipment _selectedValue;
    private Equipment SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            Model = value.Model!;
            EquipmentType = value.EquipmentType!;
        }
    }
    
    private string Model { get; set; }
    private EquipmentType EquipmentType { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public EquipmentControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Equipments = new ObservableCollection<Equipment>(Db.Equipments!);

        EquipmentTypes = new List<EquipmentType>(Db.EquipmentTypes!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        Equipment inserting = new Equipment()
        {
            Model = Model, 
            EquipmentType = EquipmentType
        };
        try
        {
            Db.Equipments!.Add(inserting);
            Db.SaveChanges();
            Equipments.Add(inserting);
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
            SelectedValue.Model = Model;
            SelectedValue.EquipmentType = EquipmentType;
            Db.Equipments!.Update(SelectedValue);
            Db.SaveChanges();
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        Equipments.Clear();
        Equipments = new ObservableCollection<Equipment>(Db.Equipments!);
    }

    private void Delete()
    {
        try
        {
            Db.Equipments!.Remove(SelectedValue);
            Db.SaveChanges();
            Equipments.Remove(SelectedValue);
        } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    