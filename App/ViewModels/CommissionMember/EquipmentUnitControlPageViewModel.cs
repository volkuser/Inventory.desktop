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
    
    private List<Status> Statuses { get; set; }
    private List<Audience> Audiences { get; set; }
    private List<State> States { get; set; }
    private List<Equipment> Equipments { get; set; }

    private EquipmentUnit _selectedValue;
    public EquipmentUnit SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;

            Series = value.Series;
            Number = value.Number!;
            Status = value.Status;
            Audience = value.Audience;
            State = value.State;
            Equipment = value.Equipment;
        }
    }

    private int Series { get; set; }
    private string Number { get; set; }
    private Status Status { get; set; }
    private Audience Audience { get; set; }
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

        Statuses = new List<Status>(Db.Statuses!);
        Audiences = new List<Audience>(Db.Audiences!);
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
            Series = Series,
            Number = Number,
            Status = Status,
            Audience = Audience,
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
        SelectedValue.Series = Series;
        SelectedValue.Number = Number;
        SelectedValue.Status = Status;
        SelectedValue.Audience = Audience;
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