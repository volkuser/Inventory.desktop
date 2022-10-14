using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class EquipmentTypeControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "equipmentType";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<EquipmentType> EquipmentTypes { get; set; }

    private EquipmentType _selectedValue;
    private EquipmentType SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            
            if (value == null) return;
            Name = value.Name!;
        }
    }
    
    private string? Name { get; set; }
    
    private ICommand OnClickBtnInsert { get; set; }
    private ICommand OnClickBtnUpdate { get; set; }
    private ICommand OnClickBtnDelete { get; set; }

    public EquipmentTypeControlViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        EquipmentTypes = new ObservableCollection<EquipmentType>(Db.EquipmentTypes!);

        OnClickBtnInsert = ReactiveCommand.Create(Insert);
        OnClickBtnUpdate = ReactiveCommand.Create(Update);
        OnClickBtnDelete = ReactiveCommand.Create(Delete);
    }
    
    private void Insert()
    {
        EquipmentType inserting = new EquipmentType()
        {
            Name = Name
        };
        EquipmentTypes.Add(inserting);
        Db.EquipmentTypes!.Add(inserting);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }

    private void Update()
    {
        SelectedValue.Name = Name;
        Db.EquipmentTypes!.Update(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
        
        EquipmentTypes.Clear();
        EquipmentTypes = new ObservableCollection<EquipmentType>(Db.EquipmentTypes!);
    }

    private void Delete()
    {
        EquipmentTypes.Remove(SelectedValue);
        Db.EquipmentTypes!.Remove(SelectedValue);
        try { Db.SaveChanges(); } catch (Exception ex) {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception", ex.Message);
            messageBox.Show();
        }
    }
}    