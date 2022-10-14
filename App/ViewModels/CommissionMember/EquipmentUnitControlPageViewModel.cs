using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class EquipmentUnitControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "equipmentUnit";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ObservableCollection<EquipmentUnit> EquipmentUnits { get; set; }
    
    private List<Availability> Availabilities { get; set; }
    private List<TrainingCenter> TrainingCenters { get; set; }
    private List<State> States { get; set; }
    private List<Equipment> Equipments { get; set; }

    private EquipmentUnit _selectedValue;

    private EquipmentUnit SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            if (value == null) return;
            SerialNumber = value.SerialNumber!;
            InventoryNumber = value.InventoryNumber!;
            Availability = value.Availability!;
            TrainingCenter = value.TrainingCenter!;
            State = value.State!;
            Equipment = value.Equipment!;
        }
    }

    private string SerialNumber { get; set; }
    private string InventoryNumber { get; set; }
    private Availability Availability { get; set; }
    private TrainingCenter TrainingCenter { get; set; }
    private State State { get; set; }
    private Equipment Equipment { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }
    
    public EquipmentUnitControlPageViewModel(User currentUser, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        EquipmentUnits = new ObservableCollection<EquipmentUnit>(Db.EquipmentUnits!);

        Availabilities = new List<Availability>(Db.Availabilities!);
        TrainingCenters = new List<TrainingCenter>(Db.TrainingCenters!);
        States = new List<State>(Db.States!);
        Equipments = new List<Equipment>(Db.Equipments!);
        
        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        EquipmentUnit inserting = new EquipmentUnit()
        {
            SerialNumber = SerialNumber,
            InventoryNumber = InventoryNumber,
            Availability = Availability,
            TrainingCenter = TrainingCenter,
            State = State,
            Equipment = Equipment,
        };
        EquipmentUnits.Add(inserting);
        Db.EquipmentUnits!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.SerialNumber = SerialNumber;
        SelectedValue.InventoryNumber = InventoryNumber;
        SelectedValue.Availability = Availability;
        SelectedValue.TrainingCenter = TrainingCenter;
        SelectedValue.State = State;
        SelectedValue.Equipment = Equipment;
        Db.EquipmentUnits!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        EquipmentUnits.Clear();
        EquipmentUnits = new ObservableCollection<EquipmentUnit>(Db.EquipmentUnits!);
    }

    private void Delete()
    {
        EquipmentUnits.Remove(SelectedValue);
        Db.EquipmentUnits!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    